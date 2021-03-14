using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.DTO;

namespace Catalog.API.Common.Interfaces
{
    /// <summary>
    /// Interface for catalog service
    /// </summary>
    public interface ICatalogService
    {
        /// <summary>
        /// Add new product category.
        /// </summary>
        /// <returns></returns>
        public Task<(int id, bool success)> AddNewCategory(CategoryDTO categoryDTO);
        
        /// <summary>
        /// Add new item.
        /// </summary>
        /// <returns></returns>
        public Task<(int id, bool success)> AddNewItem(ItemDTO itemDTO);

        /// <summary>
        /// Update category.
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateCategory(CategoryDTO categoryDTO);
        
        /// <summary>
        /// Update item
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateItem(ItemDTO itemDTO);
        
        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns></returns>
        public Task<List<CategoryDTO>> GetAllCategories();
        
        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns></returns>
        public Task<List<ItemDTO>> GetAllItems();

        /// <summary>
        /// Get category by name.
        /// </summary>
        /// <returns></returns>
        public Task<CategoryDTO> GetCategoryByName(string name);
        
        /// <summary>
        /// Get Item by name.
        /// </summary>
        /// <returns></returns>
        public Task<ItemDTO> GetItemByName(string name);
        
        /// <summary>
        /// Get category by id.
        /// </summary>
        /// <returns></returns>
        public Task<CategoryDTO> GetCategoryById(int id);
        
        /// <summary>
        /// Get Item by id.
        /// </summary>
        /// <returns></returns>
        public Task<ItemDTO> GetItemById(int id);

        /// <summary>
        /// Delete item by id.
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteItemById(int id);
        
        /// <summary>
        /// Delete item by name.
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteItemByName(string name);
        
        /// <summary>
        /// Delete category by id.
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteCategoryById(int id);
        
        /// <summary>
        /// Delete category by name.
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteCategoryByName(string name);
    }
}