using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Salon_SalonId",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_SalonId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Show");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Show",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Show_SalonId",
                table: "Show",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Salon_SalonId",
                table: "Show",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId");
        }
    }
}
