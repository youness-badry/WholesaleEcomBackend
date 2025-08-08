using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02c3ec7f-46ab-4ab1-a8ee-43994e9f2e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0892183f-1a02-4d24-8e60-0466c5ced623");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "236ffbc3-dc0b-4063-a321-658ea013fb29", "09b6ac8b-9f17-4dae-853f-fa3142081571", "Manager", "MANAGER" },
                    { "4e8c9479-18fd-47fb-87d7-f4b5ce8d1ff4", "7e2ca747-46a3-431f-82a7-67ded24a3b05", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236ffbc3-dc0b-4063-a321-658ea013fb29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e8c9479-18fd-47fb-87d7-f4b5ce8d1ff4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02c3ec7f-46ab-4ab1-a8ee-43994e9f2e1c", "b0e37790-4915-4d3e-8900-39aedf49d8e5", "Manager", "MANAGER" },
                    { "0892183f-1a02-4d24-8e60-0466c5ced623", "799d49cf-9628-42c5-b42a-0d195ad25d0f", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
