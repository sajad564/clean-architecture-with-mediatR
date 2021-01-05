using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Infrastructure.Data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea9cc0db-0f7b-42f9-8b7a-a1778c172c79", "3bdbcf6a-3aac-4181-adc6-de3124240df8", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9312329-2678-4eeb-a821-cc2a754c58fc", "beb31dc5-8c51-49fd-a6e5-531537f502e8", "author", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9312329-2678-4eeb-a821-cc2a754c58fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea9cc0db-0f7b-42f9-8b7a-a1778c172c79");
        }
    }
}
