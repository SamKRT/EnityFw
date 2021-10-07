using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuelsShop.Migrations
{
    public partial class ChangeGoodsR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetTemperature",
                table: "GoodsReceipts");

            migrationBuilder.AddColumn<double>(
                name: "MeasuredTemperature",
                table: "GoodsReceipts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasuredTemperature",
                table: "GoodsReceipts");

            migrationBuilder.AddColumn<double>(
                name: "TargetTemperature",
                table: "GoodsReceipts",
                type: "float",
                nullable: true);
        }
    }
}
