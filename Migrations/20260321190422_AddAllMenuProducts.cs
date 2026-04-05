using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AromaCoffee.Migrations
{
    /// <inheritdoc />
    public partial class AddAllMenuProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Кава із шоколадним смаком");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Кава", "Ніжна кава з вершковим смаком", "/images/raf.jpg", "Раф", 85m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Кава", "Солодкий гарячий напій", "/images/hot-chocolate.jpg", "Гарячий шоколад", 80m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Кава", "Ароматний чай на вибір", "/images/tea.jpg", "Чай", 40m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Холодна чорна кава", "/images/iced-americano.jpg", "Айс Американо", 70m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "Холодні напої", "Прохолодний кавовий напій", "/images/frappe.jpg", true, "Фрапе", 90m },
                    { 12, "Холодні напої", "Освіжаючий напій", "/images/lemonade.jpg", true, "Лимонад", 60m },
                    { 13, "Холодні напої", "Солодкий прохолодний коктейль", "/images/milkshake.jpg", true, "Молочний коктейль", 85m },
                    { 14, "Холодні напої", "Свіжовичавлений сік", "/images/orange-fresh.jpg", true, "Апельсиновий фреш", 95m },
                    { 15, "Десерти", "Ніжний вершковий десерт", "/images/cheesecake.jpg", true, "Чізкейк", 95m },
                    { 16, "Десерти", "Класичний італійський десерт", "/images/tiramisu.jpg", true, "Тірамісу", 100m },
                    { 17, "Десерти", "Хрусткий круасан із ніжною начинкою", "/images/croissant.jpg", true, "Круасан", 55m },
                    { 18, "Десерти", "Насичений шоколадний десерт", "/images/chocolate-cake.jpg", true, "Шоколадний торт", 110m },
                    { 19, "Десерти", "Солодкий пончик з глазур’ю", "/images/donut.jpg", true, "Пончик", 55m },
                    { 20, "Десерти", "Легкий французький десерт", "/images/macaron.jpg", true, "Макарон", 35m },
                    { 21, "Десерти", "Шоколадний вологий десерт", "/images/brownie.jpg", true, "Брауні", 65m },
                    { 22, "Десерти", "М’який кекс до кави", "/images/muffin.jpg", true, "Маффін", 50m },
                    { 23, "Десерти", "Заварне тістечко з кремом", "/images/eclair.jpg", true, "Еклер", 60m },
                    { 24, "Десерти", "Пишні панкейки з топінгом", "/images/pancakes.jpg", true, "Панкейки", 90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Кава з шоколадним смаком");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Десерти", "Ніжний вершковий десерт", "/images/cheesecake.jpg", "Чізкейк", 95m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Десерти", "Класичний італійський десерт", "/images/tiramisu.jpg", "Тірамісу", 100m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Десерти", "Солодкий пончик з глазур’ю", "/images/donut.jpg", "Пончик", 55m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Освіжаючий напій", "/images/lemonade.jpg", "Лимонад", 60m });
        }
    }
}
