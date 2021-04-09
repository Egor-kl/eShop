using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Baskets",
                newName: "CheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckoutId",
                table: "Baskets",
                newName: "ProfileId");
        }
    }
}
