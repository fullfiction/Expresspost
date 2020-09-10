using api.Core.Services;
using api.Core.Store;
using api.Core.Models;
using api.Infrastructure.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Countries
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class CountriesController : BaseController<Country, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        public CountriesController(UnitOfWork _uow, IMapper mapper) : base(_uow, mapper)
        {

        }
    }
}
