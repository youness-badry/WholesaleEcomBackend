using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92505977-b17c-4da9-b3e0-e272296cd292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9805e069-028b-4d33-8381-7d44fbebbb7f");

            migrationBuilder.AlterColumn<int>(
                name: "SubSubCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053ff3cd-903b-4b1a-a0b9-6f1341cbdbd6", "896ff43a-5ca7-456c-a5a9-200157494ab7", "Manager", "MANAGER" },
                    { "dc21f3aa-5129-4d4e-8f98-41194c7ac0cb", "497a43c0-c7f5-4135-b04e-9727fafcd9f0", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053ff3cd-903b-4b1a-a0b9-6f1341cbdbd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc21f3aa-5129-4d4e-8f98-41194c7ac0cb");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "SubSubCategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92505977-b17c-4da9-b3e0-e272296cd292", "48940080-a656-4328-a513-39321c8d10f2", "Administrator", "ADMINISTRATOR" },
                    { "9805e069-028b-4d33-8381-7d44fbebbb7f", "adcf6fb4-eb1b-4f92-afd0-070c64d31f6d", "Manager", "MANAGER" }
                });
        }
    }
}
