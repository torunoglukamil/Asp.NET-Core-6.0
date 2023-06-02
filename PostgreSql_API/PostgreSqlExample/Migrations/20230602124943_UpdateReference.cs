using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreSqlExample.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_productid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "orders",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_orders_productid",
                table: "orders",
                newName: "IX_orders_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_Productid",
                table: "orders",
                column: "Productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_Productid",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "orders",
                newName: "productid");

            migrationBuilder.RenameIndex(
                name: "IX_orders_Productid",
                table: "orders",
                newName: "IX_orders_productid");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_productid",
                table: "orders",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
