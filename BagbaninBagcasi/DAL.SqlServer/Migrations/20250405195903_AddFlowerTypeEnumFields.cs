using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowerTypeEnumFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrowthType",
                table: "FlowerTypes");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "FlowerTypes");

            migrationBuilder.AddColumn<string>(
                name: "GrowthTypes",
                table: "FlowerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seasons",
                table: "FlowerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7b9aac7-bf64-4d1c-a17c-e2cc2356f6cd", "AQAAAAIAAYagAAAAEO/KwgEexynCRIG6prBRlsfV4U/TDhXGbDVNiH3rUYwBaXTmFc2PBmJ7lNRL7n6Xww==", "58bcfd0b-9564-457b-bc44-c927de8b594e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrowthTypes",
                table: "FlowerTypes");

            migrationBuilder.DropColumn(
                name: "Seasons",
                table: "FlowerTypes");

            migrationBuilder.AddColumn<string>(
                name: "GrowthType",
                table: "FlowerTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "FlowerTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b445553-2033-4fd5-8144-b8131d3ac86a", "AQAAAAIAAYagAAAAEAsZsKxRFk8rY467Wbgc+ynHVlwT/9mGajIMomnDMBhSvyTrlhb6jJyWl8acpcqLng==", "efc7e6d4-c93b-4d0f-b59f-f058e261ff7b" });
        }
    }
}
