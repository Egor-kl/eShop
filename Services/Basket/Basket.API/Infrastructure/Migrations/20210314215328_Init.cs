using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Basket.API.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Baskets",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table => { table.PrimaryKey("PK_Baskets", x => x.Id); });

            migrationBuilder.CreateTable(
                "Checkouts",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>("text", nullable: false),
                    Street = table.Column<string>("text", nullable: false),
                    State = table.Column<string>("text", nullable: false),
                    Country = table.Column<string>("text", nullable: false),
                    ZipCode = table.Column<string>("text", nullable: false),
                    CardNumber = table.Column<string>("text", nullable: false),
                    CardHolderName = table.Column<string>("text", nullable: false),
                    CardExpiration = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CardSecurityNumber = table.Column<string>("text", nullable: false),
                    Buyer = table.Column<string>("text", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Checkouts", x => x.Id); });

            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false),
                    Price = table.Column<decimal>("numeric", nullable: false),
                    Description = table.Column<string>("text", nullable: false),
                    PictureFileName = table.Column<string>("text", nullable: false),
                    Amount = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Items", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Baskets");

            migrationBuilder.DropTable(
                "Checkouts");

            migrationBuilder.DropTable(
                "Items");
        }
    }
}