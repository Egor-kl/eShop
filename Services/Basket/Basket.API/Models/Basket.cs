﻿using System.Collections.Generic;

namespace Basket.API.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public int CheckoutId { get; set; }
        
        public Checkout Checkout { get; set; }
    }
}