using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleEcomBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedSetProductCharacteristicsInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristic_Characteristics_CharacteristicId",
                table: "ProductCharacteristic");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristic_Products_ProductId",
                table: "ProductCharacteristic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCharacteristic",
                table: "ProductCharacteristic");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acbf8880-1673-4c6d-9560-dbe97815da84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83934a5-9674-4ddc-864b-f9ef4ed0217f");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristic",
                newName: "ProductCharacteristics");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristic_ProductId",
                table: "ProductCharacteristics",
                newName: "IX_ProductCharacteristics_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCharacteristics",
                table: "ProductCharacteristics",
                columns: new[] { "CharacteristicId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f8cb9a4-8f13-494d-a405-52b815ee9a81", "01e64537-3129-43e7-8d90-df2a4b7d6c2a", "Administrator", "ADMINISTRATOR" },
                    { "8a20c65f-ae90-49aa-a934-a7953f96badc", "1f57e922-ac6d-44b1-9946-9077e067907b", "Manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristics_Characteristics_CharacteristicId",
                table: "ProductCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristics_Products_ProductId",
                table: "ProductCharacteristics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristics_Characteristics_CharacteristicId",
                table: "ProductCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristics_Products_ProductId",
                table: "ProductCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCharacteristics",
                table: "ProductCharacteristics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8cb9a4-8f13-494d-a405-52b815ee9a81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a20c65f-ae90-49aa-a934-a7953f96badc");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristics",
                newName: "ProductCharacteristic");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristic",
                newName: "IX_ProductCharacteristic_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCharacteristic",
                table: "ProductCharacteristic",
                columns: new[] { "CharacteristicId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "acbf8880-1673-4c6d-9560-dbe97815da84", "f6a3c497-49e7-4d20-a968-486542eb90db", "Manager", "MANAGER" },
                    { "b83934a5-9674-4ddc-864b-f9ef4ed0217f", "b963ca74-9a8d-4d71-a7b8-3bec8d9e7716", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristic_Characteristics_CharacteristicId",
                table: "ProductCharacteristic",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristic_Products_ProductId",
                table: "ProductCharacteristic",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
