using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eApp.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlAndPhoneInUserModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "VARCHAR(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);
        }
    }
}
