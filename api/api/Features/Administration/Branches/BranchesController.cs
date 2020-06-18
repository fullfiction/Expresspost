using api.Core.Services;
using api.Core.Store;
using api.Core.Store.Entities;
using api.Infrastructure.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Branches
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class BranchesController : BaseController<Branch, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        public BranchesController(UnitOfWork _uow, IMapper mapper) : base(_uow, mapper)
        {

        }
    }
}
