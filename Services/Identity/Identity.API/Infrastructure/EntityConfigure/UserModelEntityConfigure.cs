using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.EntityConfigure
{
    /// <summary>
    /// Class for user model configuration.
    /// </summary>
    public class UserModelEntityConfigure : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configure user model entity.
        /// </summary>
        /// <param name="builder">User model builder.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(user => user.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(user => user.Role)
                .IsRequired();
        }
    }
}