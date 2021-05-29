using System.Collections.Generic;

namespace Catalog.API.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Items = new List<ItemDTO>();
        }

        /// <summary>
        ///     Category identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Category name
        /// </summary>
        public string Name { get; set; }

        public ICollection<ItemDTO> Items { get; set; }
    }
}