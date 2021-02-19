namespace Catalog.API.DTO
{
    public class ItemDTO 
    {
        /// <summary>
        /// Product item identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product item price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Path to image for product
        /// </summary>
        public string PictureFileName { get; set; }

        public CategoryDTO Category { get; set; }
    }
}