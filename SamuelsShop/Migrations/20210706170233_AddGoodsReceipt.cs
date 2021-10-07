using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuelsShop.Migrations
{
    public partial class AddGoodsReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postion",
                table: "Employees",
                newName: "WorkPostion");

            migrationBuilder.AddColumn<int>(
                name: "DailyConsumption",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodsReceipts",
                columns: table => new
                {
                    GoodsReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BestBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptanceDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChargeID = table.Column<int>(type: "int", nullable: false),
                    GoodsIncomplete = table.Column<bool>(type: "bit", nullable: false),
                    GoodsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    TargetTemperature = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipts", x => x.GoodsReceiptID);
                    table.ForeignKey(
                        name: "FK_GoodsReceipts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_ProductID",
                table: "GoodsReceipts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "DailyConsumption",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WorkPostion",
                table: "Employees",
                newName: "Postion");
        }
    }
}
