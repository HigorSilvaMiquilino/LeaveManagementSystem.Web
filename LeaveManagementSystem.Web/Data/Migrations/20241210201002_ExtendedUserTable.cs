using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a98afa1-cd62-4929-9e0c-444917846e39",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba1b6a31-7afd-4b88-8bce-fcc2eb7f98cd", new DateOnly(1950, 12, 12), "Default", "Admin", "AQAAAAIAAYagAAAAEEkPoSi+/+yRQajueGIsZa8aYTz8mmaM6EfrexkvT/lodxE903CPLiR33TyuvGpirg==", "5fa39c91-b013-4ad0-b228-1d118304b646" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a98afa1-cd62-4929-9e0c-444917846e39",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c6b00f4-88a6-414b-abf4-f1434a079343", "AQAAAAIAAYagAAAAEHHdViXuHcEolUcXrWrbpC0C6dLwU0Wp3SF80qMB9FB7xPdvUcXAiHsu0mTKAqTOig==", "3f03ebc2-c7e1-49df-9d91-fb8c64aa48e1" });
        }
    }
}
