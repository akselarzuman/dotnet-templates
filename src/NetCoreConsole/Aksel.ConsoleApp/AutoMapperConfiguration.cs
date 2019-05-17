using Aksel.Models.Entities;
using Aksel.Models.Models;
using AutoMapper;

namespace Aksel.ConsoleApp
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<AkselModel, AkselEntity>();
                config.CreateMap<AkselEntity, AkselModel>();
            });
        }
    }
}