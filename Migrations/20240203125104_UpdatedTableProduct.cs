using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053ff3cd-903b-4b1a-a0b9-6f1341cbdbd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc21f3aa-5129-4d4e-8f98-41194c7ac0cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "041188d6-178f-43ba-91fb-d1ff3c387bda", "6146147b-3182-4ea8-a035-fedf138dc737", "Administrator", "ADMINISTRATOR" },
                    { "629fb8be-2f16-4e34-94c4-bc3ee3f5c431", "c5c2928e-5041-4eb7-b27d-c74880c8128d", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "041188d6-178f-43ba-91fb-d1ff3c387bda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629fb8be-2f16-4e34-94c4-bc3ee3f5c431");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053ff3cd-903b-4b1a-a0b9-6f1341cbdbd6", "896ff43a-5ca7-456c-a5a9-200157494ab7", "Manager", "MANAGER" },
                    { "dc21f3aa-5129-4d4e-8f98-41194c7ac0cb", "497a43c0-c7f5-4135-b04e-9727fafcd9f0", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
