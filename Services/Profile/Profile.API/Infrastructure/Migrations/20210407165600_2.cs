using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.API.Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "UserName",
                "Profiles",
                "text",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Email",
                "Profiles",
                "text",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "CreationDate",
                "Profiles",
                "text",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "CreationDate",
                "Profiles");

            migrationBuilder.AlterColumn<string>(
                "UserName",
                "Profiles",
                "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                "Email",
                "Profiles",
                "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}