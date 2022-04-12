using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class V342 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customer");
        }
    }
}
