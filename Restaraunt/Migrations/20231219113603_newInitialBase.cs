using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Migrations
{
    public partial class newInitialBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 19, 13, 36, 3, 303, DateTimeKind.Local).AddTicks(3381));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateOrder",
                value: new DateTime(2023, 12, 19, 9, 27, 40, 513, DateTimeKind.Local).AddTicks(1890));
        }
    }
}
