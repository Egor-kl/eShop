namespace Basket.API.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }
    }
}