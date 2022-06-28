using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.Model
{
    public class Flights
    {
        [Key]
        public int flightId { get; set; }

        
        public string FlightNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public string ScheduleDayOfWeek { get; set; }

        public int NoOfBusinessClassSeat { get; set; }
        public int NoOfNonBusinessClassSeat { get; set; }

        public int LeftBuisnessClassSeat { get; set; }
        public int LeftNonBuisnessClassSeat { get; set; }
        public int FlightBusinessClassTicketPrice { get; set; }
        public int FlightNonBusinessClassTicketPrice { get; set; }


        public string Meal { get; set; }

        public int Indicator { get; set; } = 0;

        public int airlineId { get; set; }

    }
}
