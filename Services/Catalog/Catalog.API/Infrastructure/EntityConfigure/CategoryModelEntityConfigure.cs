using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.EntityConfigure
{
    public class CategoryModelEntityConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasMany(x => x.Items);
        }
    }
}