using Identity.Common.Interfaces;
using Identity.Infrastructure.EntityConfigure;
using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure
{
    public class IdentityContext : DbContext, IIdentityContext
    {
        /// <inheritdoc/>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Constructor of identity context.
        /// </summary>
        /// <param name="options"></param>
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        /// <summary>
        /// Configure models.
        /// </summary>
        /// <param name="builder">Models configurator.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserModelEntityConfigure());
        }
    }
}