using Bristlecone.DataAccessLayer.Common;
using Bristlecone.DataAccessLayer.Entities;
using Bristlecone.DataAccessLayer.Repositories.Interfaces;
using Raven.Client;

namespace Bristlecone.DataAccessLayer.Repositories.RavenRepositories
{
    /// <summary>
    /// Derivative repository for interacting with Bristlecone Application Entities using RavenDb
    /// </summary>
    public class ApplicationRavenRepository : RavenDbRepository<Application>, IApplicationRepository
    {
        /// <summary>
        /// Creates a new Raven Repository for Applications
        /// </summary>
        /// <param name="session"></param>
        public ApplicationRavenRepository(IDocumentSession session) : base(session)
        {

        }
    }
}