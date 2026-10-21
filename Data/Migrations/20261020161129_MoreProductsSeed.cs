using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyToShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreProductsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 7, "Women", "Classic double-breasted beige trench coat.", "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?w=500", "Elegance Trench Coat", 119.99m, 25 },
                    { 8, "Women", "Cozy wool-blend turtleneck sweater in cream.", "https://images.unsplash.com/photo-1576995853123-5a10305d93c0?w=500", "Knit Turtleneck Sweater", 54.99m, 40 },
                    { 9, "Women", "Sophisticated relaxed-fit trousers for formal or casual wear.", "https://images.unsplash.com/photo-1509551388413-e18d0ac5d495?w=500", "High-Waisted Tailored Trousers", 59.99m, 35 },
                    { 10, "Men", "Comfortable everyday heavy-cotton hoodie in charcoal grey.", "https://images.unsplash.com/photo-1556905055-8f358a7a47b2?w=500", "Urban Pullover Hoodie", 44.99m, 50 },
                    { 11, "Men", "Sleek navy blue blazer for business and dinner dates.", "https://images.unsplash.com/photo-1507679799987-c73779587ccf?w=500", "Modern Fit Blazer", 139.99m, 15 },
                    { 12, "Men", "Stretch cotton slim-fit chinos in beige.", "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?w=500", "Casual Chino Pants", 49.99m, 45 },
                    { 13, "Kids", "Warm insulated jacket to keep little ones cozy in cold weather.", "https://images.unsplash.com/photo-1543854569-6f53414b4348?w=500", "Kids Winter Puffer Jacket", 39.99m, 30 },
                    { 14, "Kids", "Soft breathable 2-piece pyjama set with playful designs.", "https://images.unsplash.com/photo-1514090458221-65bb69cf63e6?w=500", "Patterned Cotton Pyjamas", 19.99m, 60 },
                    { 15, "Kids", "Lightweight slip-on sneakers with non-slip rubber soles.", "https://images.unsplash.com/photo-1511556532299-8f662fc26c06?w=500", "Kids Sporty Sneakers", 34.99m, 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
