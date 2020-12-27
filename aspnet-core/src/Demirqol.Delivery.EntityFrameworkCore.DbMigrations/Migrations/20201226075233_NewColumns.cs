using Microsoft.EntityFrameworkCore.Migrations;

namespace Demirqol.Delivery.Migrations
{
    public partial class NewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "MD_Item",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StockCount",
                table: "MD_Item",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "MD_Item");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "MD_Item");
        }
    }
}
