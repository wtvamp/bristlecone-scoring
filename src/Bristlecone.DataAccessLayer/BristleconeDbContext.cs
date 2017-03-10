using Bristlecone.DataAccessLayer.Common;
using Bristlecone.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bristlecone.DataAccessLayer
{

    public class BristleconeDbContext : BaseDbContext
    {
        public BristleconeDbContext(DbContextOptions<BristleconeDbContext> options) : base(options)
        {
            // Connection string inject in startup cs of calling application
        }

        #region DbSets<T>
        // Bristlecone dbsets, etc. go here

        public virtual DbSet<Application> Applications { get; set; }

        #endregion

    }
}
