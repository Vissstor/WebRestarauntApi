using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 19, 9, 1, 45, 776, DateTimeKind.Local).AddTicks(4974));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 17, 21, 26, 10, 677, DateTimeKind.Local).AddTicks(6385));
        }
    }
}
