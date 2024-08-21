using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson_10_identity.Migrations
{
    /// <inheritdoc />
    public partial class mig33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "12a6fed6-a588-49b3-85d4-dcc640582934", null, "admin@example.com", false, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEAMtjNO+bj8vCZ25v/DHgJ+uNAT2uNJN6RA+gUPu7zj4YOuRtWz6LXP9vdHCzBxtrA==", null, false, null, null, null, false, "adminUser" },
                    { 2, 0, null, "e751121b-3131-4c0d-babb-a961194f9b50", null, "buyer@example.com", false, false, null, "Buyer", "BUYER@EXAMPLE.COM", "BUYERUSER", "AQAAAAIAAYagAAAAEEtkHLILImZmWg5idlUBOvBKF8NA+y52ADXiFgenthZQnfF7dvM9IGS8WTrzbO0yzA==", null, false, null, null, null, false, "buyerUser" },
                    { 3, 0, null, "7a0dd1f7-2787-4912-bb9a-1e7cfbca4791", null, "seller@example.com", false, false, null, "Seller", "SELLER@EXAMPLE.COM", "SELLERUSER", "AQAAAAIAAYagAAAAEJOhMf0azgv4pUXGs0SH9gCc/LiIPBjn6N0poti14e+iCyEWwwqTfZsThONPhGUI3A==", null, false, null, null, null, false, "sellerUser" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
