using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Infrastructure.Data.Migrations
{
    public partial class Update_User_RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc3a8f09-c6b4-4845-a2af-93cb554e689a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea375c0f-fef3-459a-90e6-45811518a7de");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredRefreshTokenDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3e611f-8b26-4b5e-b5f5-3a233beca893", "249cce3a-1503-4143-8169-6a28889bb355", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21059b36-ce42-4800-9f67-048478925a5a", "4aeed70a-c564-46de-8064-6891fdac8eac", "author", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21059b36-ce42-4800-9f67-048478925a5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3e611f-8b26-4b5e-b5f5-3a233beca893");

            migrationBuilder.DropColumn(
                name: "ExpiredRefreshTokenDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea375c0f-fef3-459a-90e6-45811518a7de", "79ea562f-be16-472c-9d3e-123ba2b33312", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc3a8f09-c6b4-4845-a2af-93cb554e689a", "034edda2-73ea-4341-9f14-ea90919adc4a", "author", null });
        }
    }
}
