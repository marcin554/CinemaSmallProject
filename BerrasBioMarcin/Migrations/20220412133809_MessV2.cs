using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "Movie",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GenresName",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "Genres",
                newName: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Movie",
                newName: "GenresId");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genres",
                newName: "GenresName");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "GenresId");
        }
    }
}
