using api.Core.Store.Entities;
using AutoMapper;

namespace api.Features.Administration.Branches
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Branch, ListOut>();
            CreateMap<Branch, SingleOut>();
            CreateMap<CreateIn, Branch>();
            CreateMap<UpdateIn, Branch>();
        }
    }
}
