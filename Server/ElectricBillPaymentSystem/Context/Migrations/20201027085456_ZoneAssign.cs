using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class ZoneAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Customer");
        }
    }
}
