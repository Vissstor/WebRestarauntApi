using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Migrations
{
    public partial class InitialSeedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateOrder", "Status", "TableNumber" },
                values: new object[] { 1L, new DateTime(2023, 12, 17, 21, 20, 43, 858, DateTimeKind.Local).AddTicks(2056), 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
