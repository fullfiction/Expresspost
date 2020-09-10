using System;
using api.Core.Models;
using AutoMapper;

namespace api.Features.Administration.Employees
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, ListOut>();
            CreateMap<Employee, SingleOut>();
            CreateMap<CreateIn, Employee>();
            CreateMap<UpdateIn, Employee>();
        }
    }
}
