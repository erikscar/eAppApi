using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "Phone", "Role" },
                values: new object[] { 1, "admin@gmail.com", "Master", "https://cdn-icons-png.flaticon.com/512/17003/17003310.png", "Admin", "123", "(00) 00000-0000", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
