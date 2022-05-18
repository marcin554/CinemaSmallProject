using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spot_Booking_BookingId",
                table: "Spot");

            migrationBuilder.DropIndex(
                name: "IX_Spot_BookingId",
                table: "Spot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Spot_BookingId",
                table: "Spot",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spot_Booking_BookingId",
                table: "Spot",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingID");
        }
    }
}
