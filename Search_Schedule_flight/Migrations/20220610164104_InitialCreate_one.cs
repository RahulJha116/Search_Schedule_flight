using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class InitialCreate_one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "airlineId",
                table: "flights",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_flights_airlineId",
                table: "flights",
                column: "airlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_flights_Airlines_airlineId",
                table: "flights",
                column: "airlineId",
                principalTable: "Airlines",
                principalColumn: "airlineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_Airlines_airlineId",
                table: "flights");

            migrationBuilder.DropIndex(
                name: "IX_flights_airlineId",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "airlineId",
                table: "flights");
        }
    }
}
