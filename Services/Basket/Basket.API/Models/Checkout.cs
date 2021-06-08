using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.API.Models
{
    /// <summary>
    ///     For transfer
    /// </summary>
    public class Checkout
    {
        [Key]
        [ForeignKey("Basket")]
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
        public Basket Basket { get; set; }
    }
}