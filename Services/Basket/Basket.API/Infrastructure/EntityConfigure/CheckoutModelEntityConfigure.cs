using Basket.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.API.Infrastructure.EntityConfigure
{
    public class CheckoutModelEntityConfigure : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.HasKey(checkout => checkout.Id);
            builder.Property(checkout => checkout.Buyer).IsRequired();
            builder.Property(checkout => checkout.City).IsRequired();
            builder.Property(checkout => checkout.Country).IsRequired();
            builder.Property(checkout => checkout.State).IsRequired();
            builder.Property(checkout => checkout.Street).IsRequired();
            builder.Property(checkout => checkout.CardExpiration).IsRequired();
            builder.Property(checkout => checkout.CardNumber).IsRequired();
            builder.Property(checkout => checkout.ZipCode).IsRequired();
            builder.Property(checkout => checkout.CardHolderName).IsRequired();
            builder.Property(checkout => checkout.CardSecurityNumber).IsRequired();
        }
    }
}