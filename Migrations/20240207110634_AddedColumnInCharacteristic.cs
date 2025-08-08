using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnInCharacteristic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5ab596a-4ab4-43c5-b366-35d4b04a4115");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df984c41-f467-4010-8e24-3c56f7f8b332");

            migrationBuilder.AddColumn<bool>(
                name: "DisplayInFilters",
                table: "Characteristics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "acbf8880-1673-4c6d-9560-dbe97815da84", "f6a3c497-49e7-4d20-a968-486542eb90db", "Manager", "MANAGER" },
                    { "b83934a5-9674-4ddc-864b-f9ef4ed0217f", "b963ca74-9a8d-4d71-a7b8-3bec8d9e7716", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acbf8880-1673-4c6d-9560-dbe97815da84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83934a5-9674-4ddc-864b-f9ef4ed0217f");

            migrationBuilder.DropColumn(
                name: "DisplayInFilters",
                table: "Characteristics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5ab596a-4ab4-43c5-b366-35d4b04a4115", "f24cdcc1-fc38-4c1e-808a-c30730e791e5", "Manager", "MANAGER" },
                    { "df984c41-f467-4010-8e24-3c56f7f8b332", "eb94f6f3-4fbe-4e0a-85c7-fe560aae8541", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
