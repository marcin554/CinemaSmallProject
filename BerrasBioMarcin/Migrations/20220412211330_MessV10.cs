using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Cinema_CinemaID",
                table: "Salon");

            migrationBuilder.RenameColumn(
                name: "CinemaID",
                table: "Salon",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Salon_CinemaID",
                table: "Salon",
                newName: "IX_Salon_CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Cinema_CinemaId",
                table: "Salon",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "CinemaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Cinema_CinemaId",
                table: "Salon");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Salon",
                newName: "CinemaID");

            migrationBuilder.RenameIndex(
                name: "IX_Salon_CinemaId",
                table: "Salon",
                newName: "IX_Salon_CinemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Cinema_CinemaID",
                table: "Salon",
                column: "CinemaID",
                principalTable: "Cinema",
                principalColumn: "CinemaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
