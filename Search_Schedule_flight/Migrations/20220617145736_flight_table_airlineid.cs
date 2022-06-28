using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Search_Schedule_flight.Migrations
{
    public partial class flight_table_airlineid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_Airlines_airlineId",
                table: "flights");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropIndex(
                name: "IX_flights_airlineId",
                table: "flights");

            migrationBuilder.AlterColumn<int>(
                name: "airlineId",
                table: "flights",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "airlineId",
                table: "flights",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    airlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    airlineAddress = table.Column<string>(nullable: true),
                    airlineContactNumber = table.Column<int>(nullable: false),
                    airlineLogo = table.Column<string>(nullable: true),
                    airlineName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.airlineId);
                });

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
    }
}
