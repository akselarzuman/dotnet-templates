using AutoMapper;
using Aksel.Models.Entities;
using Aksel.Models.Models;
using Aksel.Models.ViewModels;

namespace Aksel.Auth
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<AkselViewModel, AkselModel>();
                config.CreateMap<AkselModel, AkselViewModel>();
                config.CreateMap<AkselModel, UserEntity>();
                config.CreateMap<UserEntity, AkselModel>();
            });
        }
    }
}