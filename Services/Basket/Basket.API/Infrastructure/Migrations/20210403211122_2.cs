using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "ProfileId",
                "Baskets",
                "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ProfileId",
                "Baskets");
        }
    }
}