using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CinemaName",
                table: "Salon");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Salon",
                newName: "ShowID");

            migrationBuilder.RenameColumn(
                name: "Cinema",
                table: "Salon",
                newName: "CinemaID");

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsShowCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.ShowID);
                    table.ForeignKey(
                        name: "FK_Show_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salon_CinemaID",
                table: "Salon",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_ShowID",
                table: "Salon",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "IX_Show_MovieId",
                table: "Show",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Cinema_CinemaID",
                table: "Salon",
                column: "CinemaID",
                principalTable: "Cinema",
                principalColumn: "CinemaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Show_ShowID",
                table: "Salon",
                column: "ShowID",
                principalTable: "Show",
                principalColumn: "ShowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Cinema_CinemaID",
                table: "Salon");

            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Show_ShowID",
                table: "Salon");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Salon_CinemaID",
                table: "Salon");

            migrationBuilder.DropIndex(
                name: "IX_Salon_ShowID",
                table: "Salon");

            migrationBuilder.RenameColumn(
                name: "ShowID",
                table: "Salon",
                newName: "ShowId");

            migrationBuilder.RenameColumn(
                name: "CinemaID",
                table: "Salon",
                newName: "Cinema");

            migrationBuilder.AddColumn<string>(
                name: "CinemaName",
                table: "Salon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
