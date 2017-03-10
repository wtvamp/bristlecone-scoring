using Bristlecone.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bristlecone.DataAccessLayer.Common
{
    /// <summary>
    /// BaseDbContext for any Bristlecone Code.
    /// </summary>
    public class BaseDbContext : DbContext, IContext
    {
        /// <summary>
        /// Creates a BaseDbContext for any Bristlecone DbContext
        /// </summary>
        /// <param name="context"></param>
        protected BaseDbContext(DbContextOptions context) : base(context)
        {

        }

        /// <summary>
        /// Helper function to update state using virtual function for mocking purposes
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state"></param>
        /// Excluded because Entry is not mockable in EF6
        //[ExcludeFromCodeCoverage]
        public virtual void SetState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            Entry(entity).State = state;
        }

        /// <summary>
        /// Helper function to update state using virtual function for mocking purposes
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>State of entity</returns>
        /// Excluded because Entry is not mockable in EF6
        //[ExcludeFromCodeCoverage]
        public virtual EntityState GetState<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity).State;
        }
    }
}
