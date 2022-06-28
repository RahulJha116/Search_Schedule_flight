﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Search_Schedule_flight.DbContexts;

namespace Search_Schedule_flight.Migrations
{
    [DbContext(typeof(Book_SechduleFlightContext))]
    [Migration("20220617163835_flightbooking_flightNumber")]
    partial class flightbooking_flightNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Search_Schedule_flight.Model.BookingFlight", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BusinessClass");

                    b.Property<string>("FlightNumber");

                    b.Property<string>("Meal");

                    b.Property<int>("NumberOfSeats");

                    b.Property<string>("PNR");

                    b.Property<string>("PassengerDetail");

                    b.Property<decimal>("PriceOfTicket");

                    b.Property<string>("SeatNumbers");

                    b.Property<string>("UserEmailId");

                    b.HasKey("BookingId");

                    b.ToTable("BookingFlights");
                });

            modelBuilder.Entity("Search_Schedule_flight.Model.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountAmount");

                    b.Property<string>("DiscountCode");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Search_Schedule_flight.Model.Flights", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("FlightNumber");

                    b.Property<int>("FlightTicketPrice");

                    b.Property<string>("FromPlace");

                    b.Property<int>("Indicator");

                    b.Property<int>("LeftBuisnessClassSeat");

                    b.Property<int>("LeftNonBuisnessClassSeat");

                    b.Property<string>("Meal");

                    b.Property<int>("NoOfBusinessClassSeat");

                    b.Property<int>("NoOfNonBusinessClassSeat");

                    b.Property<string>("ScheduleDayOfWeek");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<string>("ToPlace");

                    b.Property<int>("airlineId");

                    b.HasKey("flightId");

                    b.ToTable("flights");
                });

            modelBuilder.Entity("Search_Schedule_flight.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("EmailId");

                    b.Property<string>("Passkey");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
