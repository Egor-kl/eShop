using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Common.Interfaces;
using Catalog.API.DTO;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Catalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CatalogService(ICatalogContext context, IMapper mapper, ILogger logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int id, bool success)> AddNewCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(new CancellationToken());

            var id = category.Id;
            _logger.Information($"Add new category {id}, {category.Name}");

            return (id, true);
        }

        public async Task<(int id, bool success)> AddNewItem(ItemDTO itemDTO)
        {
            var item = _mapper.Map<ItemDTO, Item>(itemDTO);

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync(new CancellationToken());

            var id = item.Id;
            _logger.Information($"Add new item {id}, {item.Name}");

            return (id, true);
        }

        public async Task<bool> UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryDTO.Id);

            if (category == null)
            {
                return false;
            }

            category.Name = categoryDTO.Name;

            _context.Update(category);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> UpdateItem(ItemDTO itemDTO)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemDTO.Id);

            if (item == null)
            {
                return false;
            }

            item.Name = itemDTO.Name;
            item.Description = itemDTO.Description;
            item.Price = itemDTO.Price;
            item.PictureFileName = item.PictureFileName;

            _context.Update(item);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categoryList = await _context.Categories.ToListAsync();
            var exceptedList = _mapper.Map<List<Category>, List<CategoryDTO>>(categoryList);

            return exceptedList;
        }

        public async Task<List<ItemDTO>> GetAllItems()
        {
            var itemList = await _context.Items.ToListAsync();
            var exceptedList = _mapper.Map<List<Item>, List<ItemDTO>>(itemList);

            return exceptedList;
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
            if (category == null)
            {
                return null;
            }

            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task<ItemDTO> GetItemByName(string name)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Name == name);
            if (item == null)
            {
                return null;
            }

            var itemDTO = _mapper.Map<Item, ItemDTO>(item);

            return itemDTO;
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return null;
            }

            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task<ItemDTO> GetItemById(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                return null;
            }

            var itemDTO = _mapper.Map<Item, ItemDTO>(item);

            return itemDTO;
        }

        public async Task<bool> DeleteItemById(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                _logger.Error($"Item with id {id} not found");
                return false;
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> DeleteItemByName(string name)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Name == name);
            if (item == null)
            {
                _logger.Error($"Item with name {name} not found");
                return false;
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                _logger.Error($"Category with id {id} not found");
                return false;
            }

            _context.Remove(category);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> DeleteCategoryByName(string name)
        {
            var category = await _context.Items.FirstOrDefaultAsync(c => c.Name == name);
            if (category == null)
            {
                _logger.Error($"Category with name {name} not found");
                return false;
            }

            _context.Remove(category);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}