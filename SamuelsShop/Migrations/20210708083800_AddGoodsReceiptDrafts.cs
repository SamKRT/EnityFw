using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuelsShop.Migrations
{
    public partial class AddGoodsReceiptDrafts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Products_ProductID",
                table: "GoodsReceipts");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Products_ProductID",
                table: "GoodsReceipts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
