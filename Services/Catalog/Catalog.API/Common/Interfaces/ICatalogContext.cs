using System.Threading;
using System.Threading.Tasks;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Catalog.API.Common.Interfaces
{
    public interface ICatalogContext
    {
        DbSet<Item> Items { get; set; }
        
        DbSet<Category> Categories { get; set; }
        
        /// <summary>
        /// Save changes in application context.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Operation result.</returns>
        Task<int> SaveChangesAsync(CancellationToken token);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Updated entity.</returns>
        EntityEntry Update(object entity);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>Removed entity.</returns>
        EntityEntry Remove(object entity);
    }
}