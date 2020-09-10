using api.Core.Store;
using api.Core.Models;
using api.Infrastructure.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Companies
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class CompaniesController : BaseController<Company, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        public CompaniesController(UnitOfWork _uow, IMapper mapper) : base(_uow, mapper)
        {

        }
    }
}
