using System;

namespace Basket.API.DTO
{
    public class ChrckoutDTO
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        /// <summary>
        ///     Срок действия
        /// </summary>
        public DateTime CardExpiration { get; set; }

        /// <summary>
        ///     CVV
        /// </summary>
        public string CardSecurityNumber { get; set; }
        public BasketDTO Basket { get; set; }
    }
}