using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.API.Infrastructure.EntityConfigure
{
    public class BasketModelEntityConfigure : IEntityTypeConfiguration<Models.Basket>
    {
        public void Configure(EntityTypeBuilder<Models.Basket> builder)
        {
            builder.HasKey(basket => basket.Id);
            builder.HasMany(basket => basket.Items);
        }
    }
}