using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class MeterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer");
        }
    }
}
