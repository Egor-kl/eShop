﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.API.Infrastructure.EntityConfigure
{
    public class ProfileModelEntityConfigure : IEntityTypeConfiguration<Models.Profile>
    {
        /// <summary>
        /// Configure user model entity.
        /// </summary>
        /// <param name="builder">User model builder.</param>
        public void Configure(EntityTypeBuilder<Models.Profile> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(255);

            builder.Property(user => user.LastName)
                .HasMaxLength(255);

            builder.Property(user => user.Discount);

            builder.Property(user => user.BirthDate);

            builder.Property(user => user.Phone)
                .HasMaxLength(20);

            builder.Property(user => user.Email);
            builder.Property(user => user.UserName);

            builder.Property(user => user.UserId);
        }
    }
}