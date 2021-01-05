using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Infrastructure.Data.Migrations
{
    public partial class add_confirmation_and_resetpassword_Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9312329-2678-4eeb-a821-cc2a754c58fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea9cc0db-0f7b-42f9-8b7a-a1778c172c79");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeSendConfirmLink",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeSendRecovryLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e3b649-2ae9-4507-ad72-5d44ead4fbd4", "33cf9e22-fd8f-4b75-a948-0ddf90588846", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "828ee645-c67c-4ae1-8f07-819fb5a5d574", "60b7d675-7890-43c0-9b15-20947ba3fedd", "author", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e3b649-2ae9-4507-ad72-5d44ead4fbd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828ee645-c67c-4ae1-8f07-819fb5a5d574");

            migrationBuilder.DropColumn(
                name: "LastTimeSendConfirmLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastTimeSendRecovryLink",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea9cc0db-0f7b-42f9-8b7a-a1778c172c79", "3bdbcf6a-3aac-4181-adc6-de3124240df8", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9312329-2678-4eeb-a821-cc2a754c58fc", "beb31dc5-8c51-49fd-a6e5-531537f502e8", "author", null });
        }
    }
}
