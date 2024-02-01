using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f43fee5-1e49-4ba7-b3c6-82f6c0702439", "e212273f-4977-4e49-8ba6-8674e4fea3d0", "Administrator", "ADMINISTRATOR" },
                    { "6c38afe9-2521-4657-bb82-ca6ac1d6b973", "6579fcfe-d6e1-4d0b-9a14-3fd07b7fd863", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f43fee5-1e49-4ba7-b3c6-82f6c0702439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c38afe9-2521-4657-bb82-ca6ac1d6b973");
        }
    }
}
