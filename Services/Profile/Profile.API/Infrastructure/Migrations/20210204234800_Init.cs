using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Profile.API.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Profiles",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>("character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>("character varying(255)", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    Phone = table.Column<string>("character varying(20)", maxLength: 20, nullable: true),
                    Avatars = table.Column<byte[]>("bytea", nullable: true),
                    Discount = table.Column<double>("double precision", nullable: false),
                    Purchases = table.Column<List<string>>("text[]", nullable: true),
                    UserId = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Profiles", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Profiles");
        }
    }
}