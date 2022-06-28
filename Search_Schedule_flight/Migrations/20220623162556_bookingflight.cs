using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class bookingflight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "BookingFlights",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "BookingFlights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FromPlace",
                table: "BookingFlights",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "BookingFlights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ToPlace",
                table: "BookingFlights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "FromPlace",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "ToPlace",
                table: "BookingFlights");
        }
    }
}
