using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Common.Interfaces;
using Catalog.API.DTO;

namespace Catalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        public async Task<(int id, bool success)> AddNewCategory()
        {
            throw new System.NotImplementedException();
        }

        public async Task<(int id, bool success)> AddNewItem()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateCategory(CategoryDTO categoryDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateItem(ItemDTO itemDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ItemDTO>> GetAllItems()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemDTO> GetItemByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemDTO> GetItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteItemByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteCategoryByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}