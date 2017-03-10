using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bristlecone.DataAccessLayer.Common;

namespace Bristlecone.DataAccessLayer.Interfaces
{
    /// <summary>
    /// Interface that defines how to interact with Bristlecone Entities using the repository pattern
    /// </summary>
    /// <typeparam name="T">Type of Bristlecone Entity that derives from BaseEntity</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>An enumberable collection of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets a collection of entities that match the specified query
        /// </summary>
        /// <param name="predicate">Query by which to filter entities</param>
        /// <returns>An enumberable collection of entities filtered by the specified query</returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been added to the repository.</returns>
        T Add(T entity);

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been deleted from the repository.</returns>
        T Delete(T entity);

        /// <summary>
        /// Updates an entity in the repository
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        void Edit(T entity);

        /// <summary>
        /// Saves all changes
        /// </summary>
        void Save();
    }
}
