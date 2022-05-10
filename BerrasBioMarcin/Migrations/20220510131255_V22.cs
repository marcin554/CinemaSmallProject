using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class V22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowID",
                table: "Spot",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spot_ShowID",
                table: "Spot",
                column: "ShowID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spot_Show_ShowID",
                table: "Spot",
                column: "ShowID",
                principalTable: "Show",
                principalColumn: "ShowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spot_Show_ShowID",
                table: "Spot");

            migrationBuilder.DropIndex(
                name: "IX_Spot_ShowID",
                table: "Spot");

            migrationBuilder.DropColumn(
                name: "ShowID",
                table: "Spot");
        }
    }
}
