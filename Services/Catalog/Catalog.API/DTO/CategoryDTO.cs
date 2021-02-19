using System.Collections.Generic;

namespace Catalog.API.DTO
{
    public class CategoryDTO
    {
        /// <summary>
        /// Category identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        public List<ItemDTO> Items { get; set; }
    }
}