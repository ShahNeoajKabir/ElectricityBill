using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class UnitPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitPrice",
                columns: table => new
                {
                    UnitPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitperPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrice", x => x.UnitPriceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitPrice");
        }
    }
}
