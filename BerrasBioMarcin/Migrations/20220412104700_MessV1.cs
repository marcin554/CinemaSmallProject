using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    public partial class MessV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoviePath",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoviePath",
                table: "Movie");
        }
    }
}
