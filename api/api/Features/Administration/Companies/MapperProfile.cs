using System;
using api.Core.Store.Entities;
using AutoMapper;

namespace api.Features.Administration.Companies
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Company, ListOut>();
            CreateMap<Company, SingleOut>();
            CreateMap<CreateIn, Company>();
            CreateMap<UpdateIn, Company>();
        }
    }
}
