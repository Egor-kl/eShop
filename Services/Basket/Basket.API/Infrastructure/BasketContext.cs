using Basket.API.Common.Interfaces;
using Basket.API.Infrastructure.EntityConfigure;
using Basket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Infrastructure
{
    public class BasketContext : DbContext, IBasketContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {
        }

        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Models.Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BasketModelEntityConfigure());
            builder.ApplyConfiguration(new CheckoutModelEntityConfigure());
        }
    }
}