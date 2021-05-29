using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.API.Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Avatars",
                "Profiles");

            migrationBuilder.DropColumn(
                "Purchases",
                "Profiles");

            migrationBuilder.AddColumn<string>(
                "Email",
                "Profiles",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "UserName",
                "Profiles",
                "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Email",
                "Profiles");

            migrationBuilder.DropColumn(
                "UserName",
                "Profiles");

            migrationBuilder.AddColumn<byte[]>(
                "Avatars",
                "Profiles",
                "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                "Purchases",
                "Profiles",
                "text[]",
                nullable: true);
        }
    }
}