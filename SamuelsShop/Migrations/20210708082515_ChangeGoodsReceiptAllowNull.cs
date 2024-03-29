﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuelsShop.Migrations
{
    public partial class ChangeGoodsReceiptAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MeasuredTemperature",
                table: "GoodsReceipts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MeasuredTemperature",
                table: "GoodsReceipts",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
