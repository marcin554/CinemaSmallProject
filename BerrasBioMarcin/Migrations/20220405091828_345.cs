using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class _345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_GenresId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_GenresId",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenresId",
                table: "Movie",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genres_GenresId",
                table: "Movie",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "GenresId");
        }
    }
}
