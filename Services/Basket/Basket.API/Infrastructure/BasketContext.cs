using Basket.API.Common.Interfaces;
using Basket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Infrastructure
{
    public class BasketContext : DbContext, IBasketContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Models.Basket> Baskets { get; set; }

        public BasketContext(DbContextOptions<BasketContext> options) : base(options) {  }
    }
}