using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Migrations
{
    public partial class Base2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredientsDishies");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 19, 9, 27, 40, 513, DateTimeKind.Local).AddTicks(1890));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "OrderDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "IngredientsDishies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 19, 9, 1, 45, 776, DateTimeKind.Local).AddTicks(4974));
        }
    }
}
