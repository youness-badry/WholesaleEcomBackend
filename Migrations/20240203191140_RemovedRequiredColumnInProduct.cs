using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredColumnInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5ab596a-4ab4-43c5-b366-35d4b04a4115", "f24cdcc1-fc38-4c1e-808a-c30730e791e5", "Manager", "MANAGER" },
                    { "df984c41-f467-4010-8e24-3c56f7f8b332", "eb94f6f3-4fbe-4e0a-85c7-fe560aae8541", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5ab596a-4ab4-43c5-b366-35d4b04a4115");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df984c41-f467-4010-8e24-3c56f7f8b332");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "236ffbc3-dc0b-4063-a321-658ea013fb29", "09b6ac8b-9f17-4dae-853f-fa3142081571", "Manager", "MANAGER" },
                    { "4e8c9479-18fd-47fb-87d7-f4b5ce8d1ff4", "7e2ca747-46a3-431f-82a7-67ded24a3b05", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
