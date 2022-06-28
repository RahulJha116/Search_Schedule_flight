using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class InitialCreate_two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_Users_UserEmailIdId",
                table: "BookingFlights");

            migrationBuilder.DropIndex(
                name: "IX_BookingFlights_UserEmailIdId",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "UserEmailIdId",
                table: "BookingFlights");

            migrationBuilder.AddColumn<string>(
                name: "UserEmailId",
                table: "BookingFlights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmailId",
                table: "BookingFlights");

            migrationBuilder.AddColumn<int>(
                name: "UserEmailIdId",
                table: "BookingFlights",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_UserEmailIdId",
                table: "BookingFlights",
                column: "UserEmailIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_Users_UserEmailIdId",
                table: "BookingFlights",
                column: "UserEmailIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
