using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spot_Show_ShowID",
                table: "Spot");

            migrationBuilder.RenameColumn(
                name: "ShowID",
                table: "Spot",
                newName: "ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Spot_ShowID",
                table: "Spot",
                newName: "IX_Spot_ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spot_Show_ShowId",
                table: "Spot",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spot_Show_ShowId",
                table: "Spot");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Spot",
                newName: "ShowID");

            migrationBuilder.RenameIndex(
                name: "IX_Spot_ShowId",
                table: "Spot",
                newName: "IX_Spot_ShowID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spot_Show_ShowID",
                table: "Spot",
                column: "ShowID",
                principalTable: "Show",
                principalColumn: "ShowID");
        }
    }
}
