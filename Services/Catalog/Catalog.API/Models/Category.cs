using System.Collections.Generic;

namespace Catalog.API.Models
{
    public class Category
    {
        /// <summary>
        /// Category identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
        public Category()
        {
            Items = new List<Item>();
        }
    }
}