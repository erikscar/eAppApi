using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "ReviewsNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Offer_Range",
                table: "Products",
                sql: "[Offer] >= 1 AND [Offer] <=100");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Offer_Range",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReviewsNumber",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Offer",
                table: "Products",
                newName: "StockQuantity");
        }
    }
}
