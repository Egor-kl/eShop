﻿using System.Collections.Generic;

namespace Basket.API.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public List<int> ItemsId { get; set; }

        public Checkout Checkout { get; set; }
        
        public int ProfileId { get; set; }
    }
}