using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Search_Schedule_flight.DbContexts;
using Search_Schedule_flight.JwtAuthentication;
using Search_Schedule_flight.Model;
using Search_Schedule_flight.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Search_Schedule_flight.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookandSearchController : ControllerBase
    {
        private Book_SechduleFlightContext _dbContext;
        private readonly IBookingRepository BookingRepository;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public BookandSearchController( IBookingRepository bookingrepository, Book_SechduleFlightContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            BookingRepository = bookingrepository;
            _dbContext = dbContext;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

       // [Authorize]
        [HttpPost("BookFlight")]
        public IActionResult BookFlight([FromBody] BookingFlight bookFlight)
        {
            using (var scope = new TransactionScope())
            {
                var a = BookingRepository.bookFlight(bookFlight);
                if (a != null)
                {
                    scope.Complete();
                    return new OkObjectResult(a);
                }
                else
                    return new OkObjectResult("seats not available ");
                //return CreatedAtAction(nameof(Get), new { id = f.flightId }, f);
                
            }
            
        }
        //[Authorize]
        [HttpGet("SearchOneWay")]
        public IActionResult SearchOneWay(string fromPlace, string toPlace, DateTime flightDate)
        {
           // var fd = flightDate.ToString("MM/dd/yyyy HH:mm:ss");

            if (flightDate == DateTime.MinValue)
            {
                flightDate = DateTime.Today;
            }

            if (flightDate<= DateTime.Today.Date)
            {
                var b = "please enter flight date from today ";
                var user = JsonConvert.SerializeObject(b);
                return new OkObjectResult(user);
            }
            else
            {
                SearchModel.SearchFlight sf = new SearchModel.SearchFlight
                {
                    fromPlace = fromPlace,
                    toPlace = toPlace,
                    flightDate = flightDate
                };

                var result = BookingRepository.searchFlightOneWay(sf);

                if (result.Any())
                {
                    return new OkObjectResult(result);
                }
                else
                {
                    var b = "Flight not available ";
                    var user = JsonConvert.SerializeObject(b);
                    return new OkObjectResult(user);
                }
            }
        }

        [HttpGet("SearchRoundWay")]
        public IActionResult SearchRoundWay(string fromPlace, string toPlace, DateTime flightDate, DateTime returnDate)
        {
            if (flightDate == DateTime.MinValue || returnDate == DateTime.MinValue)
            {
                flightDate = DateTime.Today;
                returnDate = DateTime.Today;
            }

            SearchModel.SearchFlight sf = new SearchModel.SearchFlight
            {
                fromPlace = fromPlace,
                toPlace = toPlace,
                flightDate = flightDate,
                returnFlightDate = returnDate
            };

            var result = BookingRepository.searchFlightRoundWay(sf);
            if (result.Any())
            {
                return new OkObjectResult(result);
            }
            else
            {
                var b = "Flight not available ";
                var user = JsonConvert.SerializeObject(b);
                return new OkObjectResult(user);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var f = BookingRepository.GetFlightByID(id);
            return new OkObjectResult(f);
        }

        
        [HttpGet("SearchPNR")]
        public IActionResult SearchPNR(string PNR)
        {
            var f = BookingRepository.searchPNR(PNR);

            if(f.Any())
            {
                return new OkObjectResult(f);
            }
            
            var b = "PNR not Exist, check your PNR number";
            var user = JsonConvert.SerializeObject(b);
            return new OkObjectResult(user);
        }

        //[Authorize]
        [HttpGet("GetBookingHistory")]
        public IActionResult GetBookingHistory(string EmailId)
        {
            var f = BookingRepository.bookingHistory(EmailId);

            return new OkObjectResult(f);
        }

        [Authorize]
        [HttpDelete("TicketCancel")]
        public IActionResult TicketCancel(string PNR)
        {
          var f = BookingRepository.TicketCancel(PNR);

            var user = JsonConvert.SerializeObject(f);
            return new OkObjectResult(user);
        }

        [AllowAnonymous]
        [HttpPost("userLogin")]
        public IActionResult userLogin(string emailId, string passkey)
        {

            var token = jwtAuthenticationManager.Authenticate(emailId, passkey);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
