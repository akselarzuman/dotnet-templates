using Aksel.Models.Models;
using Aksel.Models.ViewModels;
using Aksel.Repository.Entities;
using AutoMapper;

namespace Aksel.AutomapperMappings
{
    public class AkselMapping : Profile
    {
        public AkselMapping()
        {
            CreateMap<AkselViewModel, AkselModel>();
            CreateMap<AkselModel, AkselEntity>();
        }
    }
}