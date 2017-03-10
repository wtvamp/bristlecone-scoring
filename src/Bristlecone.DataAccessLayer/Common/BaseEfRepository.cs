using System;
using System.Collections.Generic;
using System.Linq;
using Bristlecone.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bristlecone.DataAccessLayer.Common
{
    /// <summary>
    /// Base repository for interacting with Bristlecone Entities using Entity Framework
    /// </summary>
    /// <typeparam name="T">Type of Bristlecone Entity that derives from BaseEntity</typeparam>
    public abstract class GenericEfRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected BaseDbContext _entities;
        protected readonly DbSet<T> _dbset;

        protected GenericEfRepository(BaseDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>An enumberable collection of entities</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        /// <summary>
        /// Gets a collection of entities that match the specified query
        /// </summary>
        /// <param name="predicate">Query by which to filter entities</param>
        /// <returns>An enumberable collection of entities filtered by the specified query</returns>
        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been added to the database.</returns>
        public virtual T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been deleted from the database.</returns>
        public virtual T Delete(T entity)
        {
            _dbset.Remove(entity);
            return entity;
        }

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        public virtual void Edit(T entity)
        {
            if (_entities.GetState(entity) != EntityState.Detached)
            {
                _entities.SetState(entity, EntityState.Detached);
            }

            _entities.SetState(entity, EntityState.Modified);
        }

        /// <summary>
        /// Saves all changes on the entity framework DBContext
        /// </summary>
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
