using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Salon_SalonsSalonId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Show_ShowId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Spot_SpotsSpotID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SalonsSalonId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SpotsSpotID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SalonsSalonId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SpotsSpotID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Booking",
                newName: "ShowsID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ShowId",
                table: "Booking",
                newName: "IX_Booking_ShowsID");

            migrationBuilder.AddColumn<int>(
                name: "AmountSeats",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Show_ShowsID",
                table: "Booking",
                column: "ShowsID",
                principalTable: "Show",
                principalColumn: "ShowID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Show_ShowsID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "AmountSeats",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ShowsID",
                table: "Booking",
                newName: "ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ShowsID",
                table: "Booking",
                newName: "IX_Booking_ShowId");

            migrationBuilder.AddColumn<int>(
                name: "SalonsSalonId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpotsSpotID",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SalonsSalonId",
                table: "Booking",
                column: "SalonsSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SpotsSpotID",
                table: "Booking",
                column: "SpotsSpotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Salon_SalonsSalonId",
                table: "Booking",
                column: "SalonsSalonId",
                principalTable: "Salon",
                principalColumn: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Show_ShowId",
                table: "Booking",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Spot_SpotsSpotID",
                table: "Booking",
                column: "SpotsSpotID",
                principalTable: "Spot",
                principalColumn: "SpotID");
        }
    }
}
