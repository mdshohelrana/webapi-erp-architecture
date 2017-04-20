using System;
using System.Collections.Generic;
using EMS.Core.Domain.Entities;

namespace EMS.Core.Domain.Repository
{
    /// <summary>
    /// Repository main interface
    /// </summary>
    /// <typeparam name="TEntity">entity type of the repository</typeparam>
    /// <typeparam name="TID">id of the entity</typeparam>
    public interface IWriteOnlyRepository<TEntity> : IDisposable where TEntity : IAggregateRoot, new()
    {
        /// <summary>
        /// Add an item to repository
        /// </summary>
        /// <param name="item">item to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add an multiple item to repository
        /// </summary>
        /// <param name="item">item to add</param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entity into the repository
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Update(TEntity entity);

        /// <summary>
        /// Update multiple entity into the repository
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete multiple item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(IEnumerable<TEntity> entities);
    }
}