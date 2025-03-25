using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4bd4285-ea83-4237-be94-d41ef3471bdb", "AQAAAAIAAYagAAAAEF+MDo5RjPrCno8t8TOeFNk5FUinfbj+VECdSngW4nklr2FYEcmtp6bQVbaJGwKj4Q==", "1bd66a06-f4be-47ec-93e7-662d84fbf60e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c821f4-650f-4a2b-b65f-9f85bd60e35e", "AQAAAAIAAYagAAAAEBrRUGa64FuES+lRnUrL7cBighJXarn8KbcTOGjL91OWZmc67g/MiWR68E7RRdQgQQ==", "943e4df3-d964-4ef3-ab36-24a965739386" });
        }
    }
}
