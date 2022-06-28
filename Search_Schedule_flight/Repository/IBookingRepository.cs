using Search_Schedule_flight.Model;
using Search_Schedule_flight.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.Repository
{
    public interface IBookingRepository
    {
       IQueryable<Flights> searchFlightOneWay(SearchFlight searchFlight);

        IQueryable<Flights> searchFlightRoundWay(SearchFlight searchFlight);

        string bookFlight(BookingFlight bookFlight);

        IQueryable<BookingFlight> searchPNR(string PNR);

        IQueryable<BookingFlight> bookingHistory(string EmailId);

        string TicketCancel(string PNR);
        Flights GetFlightByID(int flightId);


    }
}
