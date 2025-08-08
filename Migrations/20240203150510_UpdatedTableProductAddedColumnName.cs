using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableProductAddedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "02c3ec7f-46ab-4ab1-a8ee-43994e9f2e1c", "b0e37790-4915-4d3e-8900-39aedf49d8e5", "Manager", "MANAGER" },
                    { "0892183f-1a02-4d24-8e60-0466c5ced623", "799d49cf-9628-42c5-b42a-0d195ad25d0f", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02c3ec7f-46ab-4ab1-a8ee-43994e9f2e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0892183f-1a02-4d24-8e60-0466c5ced623");

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
    }
}
