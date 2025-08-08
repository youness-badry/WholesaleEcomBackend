using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class Update2TableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "041188d6-178f-43ba-91fb-d1ff3c387bda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629fb8be-2f16-4e34-94c4-bc3ee3f5c431");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15b828d2-0795-408b-8c2e-6ffd4f81db16", "d411d1ca-913c-4e6c-860e-726ce55ce4d3", "Manager", "MANAGER" },
                    { "d32a19c2-f0b8-40d4-8ab9-63d5af12bab8", "37bde894-c732-43ce-9641-a5926ef434a5", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b828d2-0795-408b-8c2e-6ffd4f81db16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d32a19c2-f0b8-40d4-8ab9-63d5af12bab8");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "041188d6-178f-43ba-91fb-d1ff3c387bda", "6146147b-3182-4ea8-a035-fedf138dc737", "Administrator", "ADMINISTRATOR" },
                    { "629fb8be-2f16-4e34-94c4-bc3ee3f5c431", "c5c2928e-5041-4eb7-b27d-c74880c8128d", "Manager", "MANAGER" }
                });
        }
    }
}
