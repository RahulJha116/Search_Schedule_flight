using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.Model
{
    public class BookingFlight
    {
        [Key]
        public int BookingId { get; set; }

        public string FlightNumber { get; set; }

        public string PNR { get; set; }

        public string PassengerDetail { get; set; }

        public string Meal { get; set; }

        public bool BusinessClass { get; set; }

        public int NumberOfSeats { get; set; }

        public string SeatNumbers { get; set; }

        public Decimal PriceOfTicket { get; set; }

        public string UserEmailId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public string DiscountCode { get; set; }



    }
}
