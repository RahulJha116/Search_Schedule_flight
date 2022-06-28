using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class Add_newField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightNumber",
                table: "flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeftBuisnessClassSeat",
                table: "flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeftNonBuisnessClassSeat",
                table: "flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessClass",
                table: "BookingFlights",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FlightNumber",
                table: "BookingFlights",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "LeftBuisnessClassSeat",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "LeftNonBuisnessClassSeat",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "BusinessClass",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "BookingFlights");
        }
    }
}
