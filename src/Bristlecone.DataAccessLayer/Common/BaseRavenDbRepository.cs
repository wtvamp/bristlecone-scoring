using System;
using System.Collections.Generic;
using System.Linq;
using Bristlecone.DataAccessLayer.Interfaces;
using Raven.Client;

namespace Bristlecone.DataAccessLayer.Common
{
    /// <summary>
    /// Base repository for interacting with Bristlecone Entities using RavenDB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RavenDbRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IDocumentSession _session;

        /// <summary>
        /// Creates a RavenDbRepository using the provided DocumentSession
        /// </summary>
        /// <param name="session">RavenDb Document Session</param>
        protected RavenDbRepository(IDocumentSession session)
        {
            _session = session;
        }

        private IQueryable<T> GetQuery()
        {
            return _session.Query<T>();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>An enumberable collection of entities</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        /// <summary>
        /// Gets a collection of entities that match the specified query
        /// </summary>
        /// <param name="predicate">Query by which to filter entities</param>
        /// <returns>An enumberable collection of entities filtered by the specified query</returns>
        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _session.Query<T>()
                .Customize(x => x.WaitForNonStaleResults())
                .Where(predicate).AsEnumerable();
            return query;
        }

        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been added to the database.</returns>
        public virtual T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _session.Store(entity);

            return entity;
        }

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        /// <returns>The entity that has been deleted from the database.</returns>
        public virtual T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _session.Delete(entity);

            return entity;
        }

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">An Bristlecone Entity</param>
        public virtual void Edit(T entity)
        {
            Delete(entity);
            Save();
            Add(entity);
            Save();
        }

        /// <summary>
        /// Saves all changes on the RavenDb Document Session
        /// </summary>
        public void Save()
        {
            _session.SaveChanges();
        }

        /// <summary>
        /// Saves all changes on the RavenDb Document Session
        /// </summary>
        public void SaveChanges()
        {
            Save();
        }

        /// <summary>
        /// Disposes of the RavenDb Document Session
        /// </summary>
        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
