using AutoMapper;
using Bristlecone.DataAccessLayer.Entities;
using Bristlecone.ViewModels.DTO;

namespace Bristlecone.ServiceLayer.Common
{
    public static class AutoMapperInitialization
    {
        public static void InitializeMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Application, ApplicationDTO>();
                cfg.CreateMap<ApplicationDTO, Application>();
            });
        }
    }
}
