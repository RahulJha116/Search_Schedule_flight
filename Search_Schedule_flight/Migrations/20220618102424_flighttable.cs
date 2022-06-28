using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class flighttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlightTicketPrice",
                table: "flights",
                newName: "FlightNonBusinessClassTicketPrice");

            migrationBuilder.AddColumn<int>(
                name: "FlightBusinessClassTicketPrice",
                table: "flights",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightBusinessClassTicketPrice",
                table: "flights");

            migrationBuilder.RenameColumn(
                name: "FlightNonBusinessClassTicketPrice",
                table: "flights",
                newName: "FlightTicketPrice");
        }
    }
}
