using System;
using api.Core.Models;
using AutoMapper;

namespace api.Features.Administration.Countries
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Country, ListOut>();
            CreateMap<Country, SingleOut>();
            CreateMap<CreateIn, Country>();
            CreateMap<UpdateIn, Country>();
        }
    }
}
