using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer",
                column: "ZoneId",
                unique: true,
                filter: "[ZoneId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
