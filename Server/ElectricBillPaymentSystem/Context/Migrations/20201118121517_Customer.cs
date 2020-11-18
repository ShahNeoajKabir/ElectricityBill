using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeterNumber",
                table: "MeterTable",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterTable_MeterNumber",
                table: "MeterTable",
                column: "MeterNumber",
                unique: true,
                filter: "[MeterNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeterTable_MeterNumber",
                table: "MeterTable");

            migrationBuilder.AlterColumn<string>(
                name: "MeterNumber",
                table: "MeterTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
