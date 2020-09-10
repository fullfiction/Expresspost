using System;
using api.Core.Models;
using AutoMapper;

namespace api.Features.Administration.Localizations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Localization, ListOut>();
            CreateMap<Localization, SingleOut>();
            CreateMap<CreateIn, Localization>();
            CreateMap<UpdateIn, Localization>();
        }
    }
}
