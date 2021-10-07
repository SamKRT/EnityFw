using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuelsShop.Migrations
{
    public partial class ChangeDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipt_Products_ProductID",
                table: "GoodsReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsReceipt",
                table: "GoodsReceipt");

            migrationBuilder.RenameTable(
                name: "GoodsReceipt",
                newName: "GoodsReceipts");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceipt_ProductID",
                table: "GoodsReceipts",
                newName: "IX_GoodsReceipts_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsReceipts",
                table: "GoodsReceipts",
                column: "GoodsReceiptID");

            migrationBuilder.CreateTable(
                name: "GoodsReceiptDrafts",
                columns: table => new
                {
                    DraftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DraftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    BestBefore = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcceptanceDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChargeID = table.Column<int>(type: "int", nullable: true),
                    GoodsIncomplete = table.Column<bool>(type: "bit", nullable: true),
                    GoodsDamaged = table.Column<bool>(type: "bit", nullable: true),
                    MeasuredTemperature = table.Column<double>(type: "float", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptDrafts", x => x.DraftID);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptDrafts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptDrafts_ProductID",
                table: "GoodsReceiptDrafts",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Products_ProductID",
                table: "GoodsReceipts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Products_ProductID",
                table: "GoodsReceipts");

            migrationBuilder.DropTable(
                name: "GoodsReceiptDrafts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsReceipts",
                table: "GoodsReceipts");

            migrationBuilder.RenameTable(
                name: "GoodsReceipts",
                newName: "GoodsReceipt");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceipts_ProductID",
                table: "GoodsReceipt",
                newName: "IX_GoodsReceipt_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsReceipt",
                table: "GoodsReceipt",
                column: "GoodsReceiptID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipt_Products_ProductID",
                table: "GoodsReceipt",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
