using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.EntityConfigure
{
    public class ItemModelEntityConfigure : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);
            
            builder.Property(item => item.Name)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(item => item.Price)
                .IsRequired();
            
            builder.Property(item => item.Description)
                .IsRequired();
            
            builder.Property(item => item.PictureFileName)
                .IsRequired();
        }
    }
}