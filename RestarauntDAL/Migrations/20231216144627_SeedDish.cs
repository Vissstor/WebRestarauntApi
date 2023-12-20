using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaraunt.Migrations
{
    public partial class SeedDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1L, "A comforting and hearty dish featuring layers of tender chicken, sliced potatoes, caramelized onions, and a rich garlic-infused cream sauce. Baked until golden and bubbling, this gratin is the epitome of savory indulgence.", "Chicken and Potato Gratin" });

            migrationBuilder.InsertData(
                table: "Dishies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2L, "A light and nutritious dish that combines lean turkey with fresh spinach and creamy avocado. The turkey is seasoned to perfection, and the dish is topped with slices of ripe avocado for a burst of flavor and a touch of indulgence.", "Turkey with Spinach and Avocado" });

            migrationBuilder.InsertData(
                table: "Dishies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3L, "An elegant and flavorful dish featuring succulent baked salmon, accompanied by perfectly roasted potatoes and caramelized onions. The salmon is seasoned with herbs and spices, creating a harmonious blend of textures and tastes.", "Baked Salmon with Potato and Onion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishies",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Dishies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Dishies",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
