using System;

namespace Basket.API.Models
{
    /// <summary>
    /// For transfer
    /// </summary>
    public class Checkout
    {
        public int Id { get; set; }
        
        public string City { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public DateTime CardExpiration { get; set; }

        public string CardSecurityNumber { get; set; }

        public string Buyer { get; set; }
    }
}