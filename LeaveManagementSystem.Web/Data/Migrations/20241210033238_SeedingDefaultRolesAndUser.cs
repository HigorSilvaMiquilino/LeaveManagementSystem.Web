using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09e68d45-e2d4-4aec-9e14-f722c4917e02", null, "Employee", "EMPLOYEE" },
                    { "35dc4233-3849-419e-96c8-70dccfca8703", null, "Supervisor", "SUPERVISOR" },
                    { "d59b15cc-3039-4b05-ad57-183168d64072", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a98afa1-cd62-4929-9e0c-444917846e39", 0, "0c6b00f4-88a6-414b-abf4-f1434a079343", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHHdViXuHcEolUcXrWrbpC0C6dLwU0Wp3SF80qMB9FB7xPdvUcXAiHsu0mTKAqTOig==", null, false, "3f03ebc2-c7e1-49df-9d91-fb8c64aa48e1", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d59b15cc-3039-4b05-ad57-183168d64072", "0a98afa1-cd62-4929-9e0c-444917846e39" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e68d45-e2d4-4aec-9e14-f722c4917e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35dc4233-3849-419e-96c8-70dccfca8703");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d59b15cc-3039-4b05-ad57-183168d64072", "0a98afa1-cd62-4929-9e0c-444917846e39" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d59b15cc-3039-4b05-ad57-183168d64072");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a98afa1-cd62-4929-9e0c-444917846e39");
        }
    }
}
