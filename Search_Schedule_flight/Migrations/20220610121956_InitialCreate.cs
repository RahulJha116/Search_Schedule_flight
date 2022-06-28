using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    airlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airlineName = table.Column<string>(nullable: true),
                    airlineContactNumber = table.Column<int>(nullable: false),
                    airlineAddress = table.Column<string>(nullable: true),
                    airlineLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.airlineId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountCode = table.Column<string>(nullable: true),
                    DiscountAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    flightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ScheduleDayOfWeek = table.Column<string>(nullable: true),
                    NoOfBusinessClassSeat = table.Column<int>(nullable: false),
                    NoOfNonBusinessClassSeat = table.Column<int>(nullable: false),
                    FlightTicketPrice = table.Column<int>(nullable: false),
                    Meal = table.Column<string>(nullable: true),
                    Indicator = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.flightId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Passkey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingFlights",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PNR = table.Column<string>(nullable: true),
                    PassengerDetail = table.Column<string>(nullable: true),
                    Meal = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    SeatNumbers = table.Column<string>(nullable: true),
                    PriceOfTicket = table.Column<decimal>(nullable: false),
                    UserEmailIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingFlights", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingFlights_Users_UserEmailIdId",
                        column: x => x.UserEmailIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_UserEmailIdId",
                table: "BookingFlights",
                column: "UserEmailIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "BookingFlights");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
