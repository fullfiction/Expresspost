using System;
using api.Core.Store.Entities;
using AutoMapper;

namespace api.Features.Administration.Admins
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Admin, ListOut>();
            CreateMap<Admin, SingleOut>();
            CreateMap<CreateIn, Admin>();
            CreateMap<UpdateIn, Admin>();
        }
    }
}
