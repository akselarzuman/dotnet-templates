using AutoMapper;
using Aksel.Models.Entities;
using Aksel.Models.Models;
using Aksel.Models.ViewModels;

namespace Aksel.Api
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<AkselViewModel, AkselModel>();
                config.CreateMap<AkselModel, AkselViewModel>();
                config.CreateMap<AkselModel, AkselEntity>();
                config.CreateMap<AkselEntity, AkselModel>();
            });
        }
    }
}