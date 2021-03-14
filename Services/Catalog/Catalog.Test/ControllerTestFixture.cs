using System;
using System.Collections.Generic;
using Catalog.API.DTO;

namespace Catalog.Test
{
    public class ControllerTestFixture
    {
        /// <summary>
        /// Generate collection of Item DTO.
        /// </summary>
        /// <returns>Collection of Item DTO.</returns>
        public List<ItemDTO> GetAllItemsDTO()
        {
            return new List<ItemDTO>()
            {
                new ItemDTO()
                {
                    Id = 1,
                    Amount = 10,
                    Description = "some text",
                    Name = "Some name",
                    Price = 133.33M,
                    PictureFileName = "d:/some/some.png",
                    CategoryId = 1
                },
                
                new ItemDTO()
                {
                    Id = 2,
                    Amount = 20,
                    Description = "some text 2",
                    Name = "Some name 2",
                    Price = 33.33M,
                    PictureFileName = "d:/some/some2.png",
                    CategoryId = 1
                }
            };
        }

        /// <summary>
        /// Generate single Item DTO.
        /// </summary>
        /// <returns>Item DTO</returns>
        public ItemDTO GetItemDTO()
        {
            return new ItemDTO()
            {
                Id = 3,
                Amount = 20,
                Description = "some text 3",
                Name = "Some name 3",
                Price = 233.33M,
                PictureFileName = "d:/some/some3.png",
                CategoryId = 2
            };
        }

        /// <summary>
        /// Generate single Category DTO.
        /// </summary>
        /// <returns>Category DTO</returns>
        public CategoryDTO GetCategoryDTO()
        {
            return new CategoryDTO()
            {
                Id = 1,
                Name = "Some name category",
                Items = Array.Empty<ItemDTO>()
            };
        }

        /// <summary>
        /// Generate collection of Category DTO.
        /// </summary>
        /// <returns>Collection of Category DTO.</returns>
        public List<CategoryDTO> GetAllCategoriesDTO()
        {
            return new List<CategoryDTO>()
            {
                new CategoryDTO()
                {
                    Id = 2,
                    Name = "Some name category 2",
                    Items = Array.Empty<ItemDTO>()
                },

                new CategoryDTO()
                {
                    Id = 3,
                    Name = "Some name category 3",
                    Items = Array.Empty<ItemDTO>()
                }
            };
        }
    }
}