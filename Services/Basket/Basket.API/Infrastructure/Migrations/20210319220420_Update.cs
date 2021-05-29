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
                "Items");

            migrationBuilder.DropColumn(
                "Buyer",
                "Checkouts");

            migrationBuilder.AddColumn<int>(
                "BasketId",
                "Checkouts",
                "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<int>>(
                "ItemsId",
                "Baskets",
                "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "ProfileId",
                "Baskets",
                "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                "IX_Checkouts_BasketId",
                "Checkouts",
                "BasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                "FK_Checkouts_Baskets_BasketId",
                "Checkouts",
                "BasketId",
                "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Checkouts_Baskets_BasketId",
                "Checkouts");

            migrationBuilder.DropIndex(
                "IX_Checkouts_BasketId",
                "Checkouts");

            migrationBuilder.DropColumn(
                "BasketId",
                "Checkouts");

            migrationBuilder.DropColumn(
                "ItemsId",
                "Baskets");

            migrationBuilder.DropColumn(
                "ProfileId",
                "Baskets");

            migrationBuilder.AddColumn<string>(
                "Buyer",
                "Checkouts",
                "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>("integer", nullable: false),
                    Description = table.Column<string>("text", nullable: false),
                    Name = table.Column<string>("text", nullable: false),
                    PictureFileName = table.Column<string>("text", nullable: false),
                    Price = table.Column<decimal>("numeric", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Items", x => x.Id); });
        }
    }
}