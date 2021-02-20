using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Common.Interfaces;
using Catalog.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor of profiles controller.
        /// </summary>
        /// <param name="catalogService">Service to manage catalog.</param>
        /// <param name="logger">Logging service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CatalogController(ICatalogService catalogService, ILogger logger)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="categoryDTO">Category dto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(categoryDTO);
            }

            var (id, success) = await _catalogService.AddNewCategory(categoryDTO);
            if (!success)
            {
                _logger.Warning($"{id} conflict with add new category");
                return Conflict(new { Message = "Category already exist" });
            }
            
            categoryDTO.Id = id;

            _logger.Information($"{categoryDTO.Id} add profile success");
            return CreatedAtAction(nameof(AddNewCategory), categoryDTO);
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("/categories")]
        public async Task<ICollection<CategoryDTO>> GetAllCategories()
        {
            var categories = await _catalogService.GetAllCategories();
            var count = categories.Count;

            _logger.Information($"{count} Get categories");

            return categories;
        }
        
        /// <summary>
        /// Get category by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/category/{id}")]
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _catalogService.GetCategoryById(id);

            _logger.Information($"Get category with id {id}");

            return category;
        }
        
        /// <summary>
        /// Get category by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("/category/{name}")]
        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var category = await _catalogService.GetCategoryByName(name);

            _logger.Information($"Get category with name {name}");

            return category;
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="categoryDTO">category DTO</param>
        /// <returns></returns>
        [HttpPut("/category/{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(categoryDTO);
            }

            var categoryById = await _catalogService.GetCategoryById(categoryDTO.Id);
            if (categoryById == null)
            {
                _logger.Warning($"{categoryDTO.Id} category not found!");
                return NotFound(categoryDTO.Id);
            }

            var success = await _catalogService.UpdateCategory(categoryDTO);
            if (!success)
            {
                _logger.Warning($"{categoryDTO.Id} Conflict with update");
                return Conflict(new {Message = "Conflict with update"});
            }
            
            _logger.Information($"{categoryDTO.Id} update category success");
            return Ok(categoryDTO);
        }
        
        /// <summary>
        /// Delete category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/category/{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var categoryById = await _catalogService.GetCategoryById(id);
            if (categoryById == null)
            {
                _logger.Warning($"{categoryById.Id} category not found!");
                return NotFound();
            }

            var success = await _catalogService.DeleteCategoryById(id);
            
            _logger.Information($"Delete category with id {id} success");

            return Ok(id);
        }
    }
}