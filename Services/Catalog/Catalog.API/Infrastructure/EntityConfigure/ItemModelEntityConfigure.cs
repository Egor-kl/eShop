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

            builder.HasOne(item => item.Category)
                .WithMany(item => item.Items)
                .HasForeignKey(item => item.CategoryId);
            
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