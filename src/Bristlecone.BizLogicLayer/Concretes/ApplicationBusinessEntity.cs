using Bristlecone.BizLogicLayer.Common;
using Bristlecone.BizLogicLayer.Interfaces;
using Bristlecone.DataAccessLayer.Entities;
using Bristlecone.DataAccessLayer.Repositories.Interfaces;

namespace Bristlecone.BizLogicLayer.Concretes
{
    /// <summary>
    /// Create an Application Business Entity to handle Application Business Logic before saving to the database
    /// </summary>
    public class ApplicationBusinessEntity : BusinessEntity<Application>, IApplicationBusinessEntity
    {
        /// <summary>
        /// Constructor for injection Application repository
        /// </summary>
        /// <param name="applicationRepository"></param>
        public ApplicationBusinessEntity(IApplicationRepository applicationRepository) : base(applicationRepository)
        {
        }
    }
}