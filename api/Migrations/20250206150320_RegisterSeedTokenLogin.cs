using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RegisterSeedTokenLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cfa0548a-f3ad-43a6-b4f8-6f537341c18b", "aca41d67-2694-443d-bea4-b6229d7bb8fa", "User", "USER" },
                    { "f19b0596-b565-4771-a6bb-d5cfce1219bd", "399b2559-57a7-43cc-9301-c8c693d175a3", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfa0548a-f3ad-43a6-b4f8-6f537341c18b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19b0596-b565-4771-a6bb-d5cfce1219bd");
        }
    }
}
