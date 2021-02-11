using Microsoft.EntityFrameworkCore;
using Profile.API.Common.Interfaces;
using Profile.API.Infrastructure.EntityConfigure;

namespace Profile.API.Infrastructure
{
    public class ProfileContext : DbContext, IProfileContext
    {
        /// <summary>
        /// Constructor of identity context.
        /// </summary>
        /// <param name="options"></param>
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options) { }
        
        /// <summary>
        /// Configure models.
        /// </summary>
        /// <param name="builder">Models configurator.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProfileModelEntityConfigure());
        }
        
        /// <summary>
        /// Table of profile models;
        /// </summary>
        public DbSet<Models.Profile> Profiles { get; set; }
    }
}