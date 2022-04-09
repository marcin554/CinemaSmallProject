using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieGenre",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenresName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenresId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_GenresId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movie_GenresId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "MovieGenre",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
