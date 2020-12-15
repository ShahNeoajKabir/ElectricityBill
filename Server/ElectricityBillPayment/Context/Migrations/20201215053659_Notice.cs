using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Notice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "BillTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "BillTable");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer",
                column: "ZoneId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
