using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Show",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Cinema_CinemaId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_CinemaId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Show",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");
        }
    }
}
