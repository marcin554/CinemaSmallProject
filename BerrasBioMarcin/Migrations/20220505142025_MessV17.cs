using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Cinema_CinemaId",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_CinemaId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Show");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Show",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Show_CinemaId",
                table: "Show",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Cinema_CinemaId",
                table: "Show",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "CinemaId");
        }
    }
}
