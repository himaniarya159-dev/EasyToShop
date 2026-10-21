using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnRequests_Products_ProductId",
                table: "ReturnRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReturnRequests_ProductId",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReturnRequests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ReturnRequests");

            migrationBuilder.RenameColumn(
                name: "RequestedAt",
                table: "ReturnRequests",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Subtotal",
                table: "Orders",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "ShippingFee",
                table: "Orders",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Orders",
                newName: "PaymentMethod");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ReturnRequests",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ReturnRequests",
                newName: "RequestedAt");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "Subtotal");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Orders",
                newName: "ShippingFee");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Orders",
                newName: "DiscountAmount");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ReturnRequests",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ReturnRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ReturnRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_ProductId",
                table: "ReturnRequests",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnRequests_Products_ProductId",
                table: "ReturnRequests",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
