using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReviewsNumberOnProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewsNumber",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewsNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
