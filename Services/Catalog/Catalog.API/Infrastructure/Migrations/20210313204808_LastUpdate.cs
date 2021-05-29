using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Infrastructure.Migrations
{
    public partial class LastUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Items_Categories_CategoryId",
                "Items");

            migrationBuilder.AlterColumn<int>(
                "CategoryId",
                "Items",
                "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Items_Categories_CategoryId",
                "Items",
                "CategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Items_Categories_CategoryId",
                "Items");

            migrationBuilder.AlterColumn<int>(
                "CategoryId",
                "Items",
                "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                "FK_Items_Categories_CategoryId",
                "Items",
                "CategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}