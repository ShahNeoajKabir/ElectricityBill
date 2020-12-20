using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Zone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeterType",
                table: "UnitPrice");

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "UnitPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "UnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "MeterType",
                table: "UnitPrice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
