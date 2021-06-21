using System.Collections.Generic;

namespace Basket.API.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public Checkout Checkout { get; set; }

        public List<BasketItem> Items { get; set; }

        public int ProfileId { get; set; }
    }
}