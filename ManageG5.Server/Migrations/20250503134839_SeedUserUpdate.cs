using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageG5.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PhoneNumber", "RoleId", "UpdatedAt", "Username" },
                values: new object[] { "u00000000-0000-0000-0000-000000000002", new DateTime(2015, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "ina_hogan@example.com", "Ina Hogan", "0888888888", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2015, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "inaHogan007" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000002");
        }
    }
}
