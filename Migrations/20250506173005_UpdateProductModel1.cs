using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Offer_Range",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Offer",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Offer",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Offer_Range",
                table: "Products",
                sql: "[Offer] >= 1 AND [Offer] <=100");
        }
    }
}
