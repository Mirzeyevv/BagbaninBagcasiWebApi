using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingBuyingPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyingPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "590adb1e-1e78-410e-a811-337502077bb9", "AQAAAAIAAYagAAAAEGzucJSTmHW0GghgRpZvsDvIH+dMJpxxNMX72X2XsVzvbEeGz7bT9iimT5V0YBwQig==", "5e8ae8da-e809-4825-8d9c-c61332ef9b31" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyingPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7b9aac7-bf64-4d1c-a17c-e2cc2356f6cd", "AQAAAAIAAYagAAAAEO/KwgEexynCRIG6prBRlsfV4U/TDhXGbDVNiH3rUYwBaXTmFc2PBmJ7lNRL7n6Xww==", "58bcfd0b-9564-457b-bc44-c927de8b594e" });
        }
    }
}
