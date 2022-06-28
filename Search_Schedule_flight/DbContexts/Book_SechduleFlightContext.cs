using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Search_Schedule_flight.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight.DbContexts
{
    public class Book_SechduleFlightContext : DbContext
    {
        public Book_SechduleFlightContext()
        {

        }
        public Book_SechduleFlightContext(DbContextOptions<Book_SechduleFlightContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("BookingDB");
                optionsBuilder.UseSqlServer(connectionString);

            }



        }
       
        public DbSet<Flights> flights { get; set; }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<BookingFlight> BookingFlights { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
