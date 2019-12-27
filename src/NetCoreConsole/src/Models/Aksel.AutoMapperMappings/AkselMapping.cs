using Aksel.Models.Models;
using Aksel.Repository.Entities;
using AutoMapper;

namespace Aksel.AutomapperMappings
{
    public class AkselMapping : Profile
    {
        public AkselMapping()
        {
            CreateMap<AkselModel, AkselEntity>();
        }
    }
}