using System.Threading;
using System.Threading.Tasks;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Identity.Common.Interfaces
{
    /// <summary>
    /// Interface for identity context.
    /// </summary>
    public interface IIdentityContext
    {
        /// <summary>
        /// Table of account models;
        /// </summary>
        DbSet<User> Users { get; set; }

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