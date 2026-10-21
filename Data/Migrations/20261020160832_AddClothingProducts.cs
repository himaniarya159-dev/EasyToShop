using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyToShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClothingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { "Women", "Lightweight breathable cotton dress with floral print.", "https://images.unsplash.com/photo-1572804013309-59a88b7e92f1?w=500", "Floral Summer Dress", 49.99m, 45 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Women", "Stylish dark-wash denim jacket for all seasons.", "https://images.unsplash.com/photo-1544441893-675973e31985?w=500", "Classic Denim Jacket", 69.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { "Men", "100% premium cotton long-sleeve button-down shirt.", "https://images.unsplash.com/photo-1602810318383-e386cc2a3ccf?w=500", "Slim-Fit Casual Shirt", 39.99m, 60 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 4, "Men", "Genuine brown leather biker jacket with zip closure.", "https://images.unsplash.com/photo-1520975954732-35dd22299614?w=500", "Classic Leather Jacket", 129.99m, 20 },
                    { 5, "Kids", "Soft fleece pullover hoodie with fun cartoon prints.", "https://images.unsplash.com/photo-1519238263530-99bdd11df2ea?w=500", "Kids Graphic Hoodie", 24.99m, 50 },
                    { 6, "Kids", "Durable and comfortable cotton denim overalls for playtime.", "https://images.unsplash.com/photo-1519457431-44ccd64a579b?w=500", "Kids Denim Overalls", 29.99m, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { "Black | Premium Series", "/images/default.png", "Wireless Headphones", 129.99m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Silver | Series 7", "/images/default.png", "Smart Watch", 299.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { "White | 15W Fast Charge", "/images/default.png", "Wireless Charger", 49.99m, 100 });
        }
    }
}
