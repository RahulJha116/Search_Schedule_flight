using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.SearchModel
{
    //string fromPlace, string toPlace, DateTime flightDate, DateTime returnFlightDate
    public class SearchFlight
    {
        public string fromPlace { get; set; }

        public string toPlace { get; set; }

        public DateTime? flightDate { get; set; }

        public DateTime? returnFlightDate { get; set; }
    }
}
