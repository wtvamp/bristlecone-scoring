using Bristlecone.DataAccessLayer.Common;
using Bristlecone.DataAccessLayer.Entities;
using Bristlecone.DataAccessLayer.Repositories.Interfaces;

namespace Bristlecone.DataAccessLayer.Repositories.EfRepositories
{
    /// <summary>
    /// Derivative repository for interacting with Bristlecone Application Entities using Entity Framework
    /// </summary>
    public class ApplicationEfRepository : GenericEfRepository<Application>, IApplicationRepository
    {
        /// <summary>
        /// Creates a new Entity Framework backed Application Repository
        /// </summary>
        /// <param name="context"></param>
        public ApplicationEfRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
