using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSpace = table.Column<int>(type: "int", nullable: false),
                    CinemaID = table.Column<int>(type: "int", nullable: false),
                    ShowsShowID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.SalonId);
                    table.ForeignKey(
                        name: "FK_Salon_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "CinemaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salon_Show_ShowsShowID",
                        column: x => x.ShowsShowID,
                        principalTable: "Show",
                        principalColumn: "ShowID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salon_CinemaID",
                table: "Salon",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_ShowsShowID",
                table: "Salon",
                column: "ShowsShowID");

            migrationBuilder.CreateIndex(
                name: "IX_Show_MovieId",
                table: "Show",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "Show");
        }
    }
}
