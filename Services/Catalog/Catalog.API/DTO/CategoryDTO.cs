﻿using System.Collections.Generic;
using Catalog.API.Models;

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
        
        public ICollection<ItemDTO> Items { get; set; }
        public CategoryDTO()
        {
            Items = new List<ItemDTO>();
        }
    }
}