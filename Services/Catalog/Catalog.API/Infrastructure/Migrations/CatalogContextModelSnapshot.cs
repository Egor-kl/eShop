﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Catalog.API.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    internal class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Catalog.API.Models.Category", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.HasKey("Id");

                b.ToTable("Categories");
            });

            modelBuilder.Entity("Catalog.API.Models.Item", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();

                b.Property<int>("Amount")
                    .HasColumnType("integer");

                b.Property<int>("CategoryId")
                    .HasColumnType("integer");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.Property<string>("PictureFileName")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<decimal>("Price")
                    .HasColumnType("numeric");

                b.HasKey("Id");

                b.HasIndex("CategoryId");

                b.ToTable("Items");
            });

            modelBuilder.Entity("Catalog.API.Models.Item", b =>
            {
                b.HasOne("Catalog.API.Models.Category", "Category")
                    .WithMany("Items")
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Category");
            });

            modelBuilder.Entity("Catalog.API.Models.Category", b => { b.Navigation("Items"); });
#pragma warning restore 612, 618
        }
    }
}