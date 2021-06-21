using System.Collections.Generic;

namespace Basket.API.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }

        public ChrckoutDTO Checkout { get; set; }

        public List<BasketItemDTO> Items { get; set; }

        public int ProfileId { get; set; }
    }
}