using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingPaidAmountToDebt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Debts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bdd931e-d041-4b40-9281-0d22ac22a572", "AQAAAAIAAYagAAAAECa4qaBtb+vLdfd7Yj3JmqZbohlVMyLSEWy1GFU9tjKn7ddeGrR5Jq3RsLOwvG6rPw==", "35d61c42-1aba-47cf-8f6d-cdfc81be4cd9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Debts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c10c9801-9957-4018-8e48-0c7812d47b50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4bd4285-ea83-4237-be94-d41ef3471bdb", "AQAAAAIAAYagAAAAEF+MDo5RjPrCno8t8TOeFNk5FUinfbj+VECdSngW4nklr2FYEcmtp6bQVbaJGwKj4Q==", "1bd66a06-f4be-47ec-93e7-662d84fbf60e" });
        }
    }
}
