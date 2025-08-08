using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableProductRemovedNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b828d2-0795-408b-8c2e-6ffd4f81db16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d32a19c2-f0b8-40d4-8ab9-63d5af12bab8");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d585670c-b0a5-421f-a1e3-6922ae4c5f6a", "6c8826c6-1a02-4bea-89ae-4444125aaf44", "Administrator", "ADMINISTRATOR" },
                    { "df5ab72c-6c7b-4d0a-9e03-f4e3320435db", "9986bf72-ac0b-454b-855a-746f120e958e", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d585670c-b0a5-421f-a1e3-6922ae4c5f6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df5ab72c-6c7b-4d0a-9e03-f4e3320435db");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15b828d2-0795-408b-8c2e-6ffd4f81db16", "d411d1ca-913c-4e6c-860e-726ce55ce4d3", "Manager", "MANAGER" },
                    { "d32a19c2-f0b8-40d4-8ab9-63d5af12bab8", "37bde894-c732-43ce-9641-a5926ef434a5", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
