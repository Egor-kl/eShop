using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.API.Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatars",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Purchases",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Profiles",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Profiles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatars",
                table: "Profiles",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Purchases",
                table: "Profiles",
                type: "text[]",
                nullable: true);
        }
    }
}
