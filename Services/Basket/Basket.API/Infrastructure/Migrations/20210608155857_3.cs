using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CheckoutId",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Checkouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Baskets_Id",
                table: "Checkouts",
                column: "Id",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Baskets_Id",
                table: "Checkouts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Checkouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Checkouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
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
    }
}
