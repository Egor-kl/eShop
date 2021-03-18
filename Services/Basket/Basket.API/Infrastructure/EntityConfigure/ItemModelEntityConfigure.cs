﻿using Basket.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.API.Infrastructure.EntityConfigure
{
    public class ItemModelEntityConfigure : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Amount).IsRequired();
            builder.Property(item => item.PictureFileName).IsRequired();
            builder.Property(item => item.Description).IsRequired();
            builder.Property(item => item.Name).IsRequired();
            builder.Property(item => item.Price).IsRequired();
        }
    }
}