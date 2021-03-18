using System.Collections.Generic;

namespace Basket.API.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public List<Item> Items { get; set; }
    }
}