using System.Threading.Tasks;
using Bristlecone.DataAccessLayer.Entities;
using Bristlecone.ServiceLayer.Common;
using Bristlecone.ViewModels.DTO;
using BristleCone.ServiceLayer.Common;

namespace Bristlecone.ServiceLayer.Interfaces
{

    public interface IApplicationService : IEntityService<Application>
    {
        Task<ApplicationDTO> GetApplicationAsync(long id);

        Task<ResponseDTO> CreateApplicationAsync(ApplicationDTO applicationDto);

        Task<ResponseDTO> UpdateApplicationAsync(ApplicationDTO applicationDto);
    }

}