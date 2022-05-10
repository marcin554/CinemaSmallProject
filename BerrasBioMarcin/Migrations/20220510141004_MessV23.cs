using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    SalonsSalonId = table.Column<int>(type: "int", nullable: true),
                    SpotsSpotID = table.Column<int>(type: "int", nullable: true),
                    BookingCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Salon_SalonsSalonId",
                        column: x => x.SalonsSalonId,
                        principalTable: "Salon",
                        principalColumn: "SalonId");
                    table.ForeignKey(
                        name: "FK_Booking_Show_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Show",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Spot_SpotsSpotID",
                        column: x => x.SpotsSpotID,
                        principalTable: "Spot",
                        principalColumn: "SpotID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SalonsSalonId",
                table: "Booking",
                column: "SalonsSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ShowId",
                table: "Booking",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SpotsSpotID",
                table: "Booking",
                column: "SpotsSpotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
