using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageG5.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedDocUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { "10000000-0000-0000-0000-000000000003", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2024 Q1 goals", "Marketing Strategy" },
                    { "10000000-0000-0000-0000-000000000004", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Next year's projections", "Budget Forecast" },
                    { "10000000-0000-0000-0000-000000000005", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Infrastructure rules", "IT Guidelines" },
                    { "10000000-0000-0000-0000-000000000006", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company-wide security practices", "Security Policy" },
                    { "10000000-0000-0000-0000-000000000007", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recruitment targets", "Hiring Plan" },
                    { "10000000-0000-0000-0000-000000000008", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Board meetings notes", "Meeting Minutes" },
                    { "10000000-0000-0000-0000-000000000009", new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "New hire onboarding", "Training Manual" },
                    { "10000000-0000-0000-0000-000000000010", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate Social Responsibility update", "CSR Report" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PhoneNumber", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { "u00000000-0000-0000-0000-000000000003", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John Smith", "0911111111", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnnyS" },
                    { "u00000000-0000-0000-0000-000000000004", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "Sara Lee", "0922222222", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "saraLee" },
                    { "u00000000-0000-0000-0000-000000000005", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruce@example.com", "Bruce Wayne", "0933333333", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "batman" },
                    { "u00000000-0000-0000-0000-000000000006", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "clark@example.com", "Clark Kent", "0944444444", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superman" },
                    { "u00000000-0000-0000-0000-000000000007", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@example.com", "Peter Parker", "0955555555", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "spidey" },
                    { "u00000000-0000-0000-0000-000000000008", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tony@example.com", "Tony Stark", "0966666666", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ironman" },
                    { "u00000000-0000-0000-0000-000000000009", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana@example.com", "Diana Prince", "0977777777", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wonderwoman" },
                    { "u00000000-0000-0000-0000-000000000010", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "steve@example.com", "Steve Rogers", "0988888888", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cap" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000006");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000007");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000008");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000009");

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: "10000000-0000-0000-0000-000000000010");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000006");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000007");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000008");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000009");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "u00000000-0000-0000-0000-000000000010");
        }
    }
}
