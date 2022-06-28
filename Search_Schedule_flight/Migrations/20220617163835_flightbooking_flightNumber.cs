using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class flightbooking_flightNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "BookingFlights",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FlightNumber",
                table: "BookingFlights",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
