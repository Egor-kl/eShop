using System.Collections.Generic;
using Catalog.API.DTO;

namespace Catalog.Tests
{
    public class ControllerTestFixture
    {
        /// <summary>
        /// Generate collection of Item DTO.
        /// </summary>
        /// <returns>Collection of Item DTO.</returns>
        public List<ItemDTO> GetAllItems()
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
                    PictureFileName = "d:/some/some.png"
                },
                
                new ItemDTO()
                {
                    Id = 2,
                    Amount = 20,
                    Description = "some text 2",
                    Name = "Some name 2",
                    Price = 33.33M,
                    PictureFileName = "d:/some/some2.png"
                }
            };
        }

        /// <summary>
        /// Generate single Item DTO.
        /// </summary>
        /// <returns>Item DTO</returns>
        public ItemDTO GetItem()
        {
            return new ItemDTO()
            {
                Id = 3,
                Amount = 20,
                Description = "some text 3",
                Name = "Some name 3",
                Price = 233.33M,
                PictureFileName = "d:/some/some3.png"
            };
        }
    }
}