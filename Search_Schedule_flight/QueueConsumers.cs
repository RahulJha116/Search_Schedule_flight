using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Search_Schedule_flight.DbContexts;
using Search_Schedule_flight.Model;
using Search_Schedule_flight.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Schedule_flight
{
    public class QueueConsumers
    {
        private static Book_SechduleFlightContext context;
        private static IBookingRepository bookingRepository;

        private static void GetHelperConfiguration(Book_SechduleFlightContext _context)
        {
            context = _context;
            bookingRepository = new BookingRepository(context);

        }

        public static void Consumer(string QueueName)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (Sender, e) =>
            {

                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                if (QueueName == "AddDiscountQueue" && !string.IsNullOrEmpty(message))
                {

                    var discount = new Discount();
                    
                        var chunks = message.Split("|");
                        if (chunks.Length != 0)
                        {
                            discount.DiscountCode = chunks[0];
                            discount.DiscountAmount = Int32.Parse(chunks[1]);
                        }

                    Book_SechduleFlightContext db = new Book_SechduleFlightContext();
                    db.Add(discount);
                    db.SaveChanges();
                    Console.WriteLine(message);
                }
                else if (QueueName == "AddAirlineBlockQueue" && !string.IsNullOrEmpty(message))
                {
                    var Flight = new Flights();
                    Task.Run(() =>
                    {
                        var chunks = message;
                        if (chunks != null)
                        {

                            Book_SechduleFlightContext _dbContext = new Book_SechduleFlightContext();
                            foreach (var value in _dbContext.flights)
                            {
                                if (value.airlineId == Int32.Parse(chunks))
                                {
                                    value.Indicator = 1;

                                }


                            }
                            _dbContext.SaveChanges();

                        }


                    });
                }
                else if (QueueName == "AddAirlineUnBlockQueue" && !string.IsNullOrEmpty(message))
                {
                    var Flight = new Flights();
                    Task.Run(() =>
                    {
                        var chunks = message;
                        if (chunks != null)
                        {

                            Book_SechduleFlightContext _dbContext = new Book_SechduleFlightContext();
                            foreach (var value in _dbContext.flights)
                            {
                                if (value.airlineId == Int32.Parse(chunks))
                                {
                                    value.Indicator = 0;

                                }


                            }
                            _dbContext.SaveChanges();

                        }


                    });
                }
                else if (QueueName == "DeleteDiscountQueue" && !string.IsNullOrEmpty(message))
                {
                    var Flight = new Flights();
                    Task.Run(() =>
                    {
                        var chunks = Int32.Parse(message);
                        if (chunks != 0)
                        {

                            Book_SechduleFlightContext _dbContext = new Book_SechduleFlightContext();
                            var f = _dbContext.Discounts.Find(chunks);
                            _dbContext.Discounts.Remove(f);
                            _dbContext.SaveChanges();

                        }


                    }

                    );
                }
                else if(QueueName == "AddFlightQueue" && !string.IsNullOrEmpty(message))
                {
                    var Flight = new Flights();
                    Task.Run(() =>
                    {
                        var chunks = message.Split("|");
                        if (chunks.Length != 0)
                        {
                            Flight.FromPlace = chunks[0];
                            Flight.ToPlace = chunks[1];
                            Flight.StartDateTime = DateTime.Parse(chunks[2]);
                            Flight.EndDateTime = DateTime.Parse(chunks[3]);
                            Flight.FlightNumber = chunks[4];
                            Flight.ScheduleDayOfWeek = chunks[5];
                            Flight.NoOfBusinessClassSeat = Int32.Parse(chunks[6]);
                            Flight.NoOfNonBusinessClassSeat = Int32.Parse(chunks[7]);
                            Flight.LeftBuisnessClassSeat = Int32.Parse(chunks[6]);
                            Flight.LeftNonBuisnessClassSeat = Int32.Parse(chunks[7]);
                            Flight.FlightBusinessClassTicketPrice = Int32.Parse(chunks[8]);
                            Flight.FlightNonBusinessClassTicketPrice = Int32.Parse(chunks[9]);
                            Flight.Indicator = Int32.Parse(chunks[10]);
                            Flight.airlineId = Int32.Parse(chunks[11]);
                            Flight.Meal = chunks[12];


                        }


                    }

                    );
                    Book_SechduleFlightContext db = new Book_SechduleFlightContext();
                    db.Add(Flight);
                    db.SaveChanges();
                    Console.WriteLine(message);
                }

            };
            channel.BasicConsume(QueueName, true, consumer);

         }
    }
}
