using Search_Schedule_flight.DbContexts;
using Search_Schedule_flight.Model;
using Search_Schedule_flight.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Book_SechduleFlightContext _dbContext;
        public BookingRepository(Book_SechduleFlightContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string bookFlight(BookingFlight bookFlight)
        {
            string a = RandomString(7);
            BookingFlight booking = new BookingFlight
            {
                FlightNumber = bookFlight.FlightNumber,
                BusinessClass = bookFlight.BusinessClass,
                NumberOfSeats = bookFlight.NumberOfSeats,//UpdateSeatFlight(bookFlight.FlightNumber,bookFlight.BusinessClass,bookFlight.NumberOfSeats),
                Meal = bookFlight.Meal,
                PassengerDetail = bookFlight.PassengerDetail,
                DiscountCode= bookFlight.DiscountCode,
                PriceOfTicket = bookFlight.PriceOfTicket- discountAmont(bookFlight.DiscountCode),
                SeatNumbers = bookFlight.SeatNumbers,
                UserEmailId = bookFlight.UserEmailId,
                StartDateTime= bookFlight.StartDateTime,
                EndDateTime=bookFlight.EndDateTime,
                FromPlace=bookFlight.FromPlace,
                ToPlace=bookFlight.ToPlace,
                PNR = a
            };

            if (booking.NumberOfSeats != 0)
            {
                _dbContext.Add(booking);
                _dbContext.SaveChanges();
                return a;
            }
            else
            {
                return null;
            }
                 
        
        }

        public int discountAmont(string discountCode)
        {
            
            Discount b = _dbContext.Discounts.Where(p => p.DiscountCode == discountCode).FirstOrDefault();

            if(b!= null)
            {
                return b.DiscountAmount;
            }
            return 0;

        }

        //public int UpdateSeatFlight(string flightNumber, bool businessIndicator, int noOfSeats)
        //{
            
        //    int b=0;
        //    var a = searchFlightNumber(flightNumber);

            

        //    if(a != null)
        //    {
        //        if (businessIndicator == true & a.First().LeftBuisnessClassSeat >= noOfSeats)
        //        {
        //            a.First().LeftBuisnessClassSeat = a.First().NoOfBusinessClassSeat - noOfSeats;
        //            _dbContext.SaveChanges();
        //            b = noOfSeats;
        //        }
        //        else if (businessIndicator == false & a.First().LeftNonBuisnessClassSeat >=noOfSeats)
        //        {
        //            a.First().LeftNonBuisnessClassSeat -= noOfSeats;
        //            _dbContext.SaveChanges();
        //            b = noOfSeats;
        //        }
        //        else
        //            b= 0;

        //    }

        //    return b;
        //}

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqestuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

       

        public IQueryable<Flights> searchFlightOneWay(SearchFlight searchFlight)
        {
            var result = _dbContext.flights.AsQueryable();
            if(searchFlight != null )
            {
                if(!string.IsNullOrEmpty(searchFlight.fromPlace))
                {
                    result = result.Where(x => x.FromPlace == searchFlight.fromPlace);

                }
                if (!string.IsNullOrEmpty(searchFlight.toPlace))
                {
                    result = result.Where(x => x.ToPlace == searchFlight.toPlace);

                }
                if ((searchFlight.flightDate.HasValue))
                {
                    result = result.Where(x => (x.StartDateTime.Date == searchFlight.flightDate.Value.Date) && (x.Indicator ==0));

                }

            }
            return result;
        }

        public IQueryable<Flights> searchFlightRoundWay(SearchFlight searchFlight)
        {
            var result = _dbContext.flights.AsQueryable();
            if (searchFlight != null)

            {
                if (!string.IsNullOrEmpty(searchFlight.fromPlace) || (!string.IsNullOrEmpty(searchFlight.toPlace)))
                {
                    result = result.Where(x => (x.FromPlace == searchFlight.fromPlace) || (x.FromPlace == searchFlight.toPlace));

                }
                if (!string.IsNullOrEmpty(searchFlight.toPlace) || (!string.IsNullOrEmpty(searchFlight.fromPlace)))
                {
                    result = result.Where(x => (x.ToPlace == searchFlight.toPlace) || (x.ToPlace == searchFlight.fromPlace));

                }
                
                if ((searchFlight.flightDate.HasValue) || (searchFlight.returnFlightDate.HasValue))
                {
                    result = result.Where(x => (x.StartDateTime.Date == searchFlight.flightDate.Value.Date || x.StartDateTime.Date == searchFlight.returnFlightDate.Value.Date) && (x.Indicator
                    ==0));

                }
              
            }

            return result;
        }
        public string TicketCancel(string PNR)
        {
            BookingFlight b = _dbContext.BookingFlights.Where(p => p.PNR == PNR).FirstOrDefault();
            

            if (b!=null)
            {
                int a = b.BookingId;


                var f = _dbContext.BookingFlights.Find(a);

                _dbContext.BookingFlights.Remove(f);
                _dbContext.SaveChanges();
                return "booking cancelled";
            }
            else
            {
                return "PNR not valid, pls check";
            }
        }
        public IQueryable<BookingFlight> searchPNR(string PNR)
        {
            var result = _dbContext.BookingFlights.AsQueryable();
            if (PNR != null)
            {
                if (!string.IsNullOrEmpty(PNR))
                {
                    result = result.Where(x => x.PNR == PNR);

                }
               
            }
            else
            {
                result = null;
            }
            return result;
        }
        public IQueryable<Flights> searchFlightNumber(string flightNumber)
        {
            var result = _dbContext.flights.AsQueryable();
            if (flightNumber != null)
            {
                if (!string.IsNullOrEmpty(flightNumber))
                {
                    result = result.Where(x => x.FlightNumber == flightNumber);

                }

            }
            return result;
        }
        public Flights GetFlightByID(int flightId)
        {
            return _dbContext.flights.Find(flightId);
        }

        public IQueryable<BookingFlight> bookingHistory(string EmailId)
        {
            var result = _dbContext.BookingFlights.AsQueryable();
            if (EmailId != null)
            {
                if (!string.IsNullOrEmpty(EmailId))
                {
                    result = result.Where(x => x.UserEmailId == EmailId);

                }

            }
            return result;
        }

       
    }
}
