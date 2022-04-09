using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_GenresId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_GenresId",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "GenresId",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GenresId",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
