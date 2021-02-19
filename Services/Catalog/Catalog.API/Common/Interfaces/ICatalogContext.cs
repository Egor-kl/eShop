using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Common.Interfaces
{
    public interface ICatalogContext
    {
        DbSet<Item> Items { get; set; }
        
        DbSet<Category> Categories { get; set; }
    }
}