using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Infrastructure.Data.Migrations
{
    public partial class update_deletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Books_BookId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e3b649-2ae9-4507-ad72-5d44ead4fbd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828ee645-c67c-4ae1-8f07-819fb5a5d574");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea375c0f-fef3-459a-90e6-45811518a7de", "79ea562f-be16-472c-9d3e-123ba2b33312", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc3a8f09-c6b4-4845-a2af-93cb554e689a", "034edda2-73ea-4341-9f14-ea90919adc4a", "author", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Books_BookId",
                table: "Files",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Books_BookId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc3a8f09-c6b4-4845-a2af-93cb554e689a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea375c0f-fef3-459a-90e6-45811518a7de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e3b649-2ae9-4507-ad72-5d44ead4fbd4", "33cf9e22-fd8f-4b75-a948-0ddf90588846", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "828ee645-c67c-4ae1-8f07-819fb5a5d574", "60b7d675-7890-43c0-9b15-20947ba3fedd", "author", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Books_BookId",
                table: "Files",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
