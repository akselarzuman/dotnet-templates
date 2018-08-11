using AutoMapper;
using Armut.Models.Entities;
using Armut.Models.Models;
using Armut.Models.ViewModels;

namespace Armut.Api
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<ArmutViewModel, ArmutModel>();
                config.CreateMap<ArmutModel, ArmutEntity>();
            });
        }
    }
}