using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Notice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZoneId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BillId",
                table: "Payment",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer",
                column: "ZoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillTable_MeterReadingId",
                table: "BillTable",
                column: "MeterReadingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillTable_MeterReadingTable_MeterReadingId",
                table: "BillTable",
                column: "MeterReadingId",
                principalTable: "MeterReadingTable",
                principalColumn: "MeterReadingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_BillTable_BillId",
                table: "Payment",
                column: "BillId",
                principalTable: "BillTable",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillTable_MeterReadingTable_MeterReadingId",
                table: "BillTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Zone_ZoneId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BillTable_BillId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BillId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ZoneId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_BillTable_MeterReadingId",
                table: "BillTable");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "Customer");
        }
    }
}
