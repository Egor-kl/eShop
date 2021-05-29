using Catalog.API.Common.Interfaces;
using Catalog.API.Infrastructure.EntityConfigure;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext, ICatalogContext
    {
        /// <summary>
        ///     Constructor of identity context.
        /// </summary>
        /// <param name="options"></param>
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        ///     Configure models.
        /// </summary>
        /// <param name="builder">Models configurator.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemModelEntityConfigure());
            builder.ApplyConfiguration(new CategoryModelEntityConfigure());
        }
    }
}