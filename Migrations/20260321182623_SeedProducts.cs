using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AromaCoffee.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Кава", "Міцна класична кава", "/images/espresso.jpg", true, "Еспресо", 45m },
                    { 2, "Кава", "Ароматна чорна кава", "/images/americano.jpg", true, "Американо", 50m },
                    { 3, "Кава", "Кава з ніжною молочною пінкою", "/images/cappuccino.jpg", true, "Капучино", 65m },
                    { 4, "Кава", "М’яка кава з молоком", "/images/latte.jpg", true, "Лате", 70m },
                    { 5, "Кава", "Кава з шоколадним смаком", "/images/mocha.jpg", true, "Мокачино", 75m },
                    { 6, "Десерти", "Ніжний вершковий десерт", "/images/cheesecake.jpg", true, "Чізкейк", 95m },
                    { 7, "Десерти", "Класичний італійський десерт", "/images/tiramisu.jpg", true, "Тірамісу", 100m },
                    { 8, "Десерти", "Солодкий пончик з глазур’ю", "/images/donut.jpg", true, "Пончик", 55m },
                    { 9, "Холодні напої", "Освіжаючий напій", "/images/lemonade.jpg", true, "Лимонад", 60m },
                    { 10, "Холодні напої", "Холодна кава з молоком", "/images/iced-latte.jpg", true, "Айс Лате", 80m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
