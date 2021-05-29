using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "ProfileId",
                "Baskets",
                "CheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "CheckoutId",
                "Baskets",
                "ProfileId");
        }
    }
}