using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class UseRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MobileBankingType",
                table: "MobileBanking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileBankingType",
                table: "MobileBanking");
        }
    }
}
