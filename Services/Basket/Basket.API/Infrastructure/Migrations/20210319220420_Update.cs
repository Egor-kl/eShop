using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "Checkouts");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Checkouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<int>>(
                name: "ItemsId",
                table: "Baskets",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Baskets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BasketId",
                table: "Checkouts",
                column: "BasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Baskets_BasketId",
                table: "Checkouts",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Baskets_BasketId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BasketId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "Checkouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }
    }
}
