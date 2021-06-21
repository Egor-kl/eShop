namespace Basket.API.Models
{
    public class BasketItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Item title / name
        /// </summary>
        public string ItemName { get; set; }
        
        /// <summary>
        /// Price
        /// </summary>
        public decimal ItemPrice { get; set; }
        
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}