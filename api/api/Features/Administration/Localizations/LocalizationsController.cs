using api.Core.Store;
using api.Core.Models;
using api.Infrastructure.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Localizations
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class LocalizationsController : BaseController<Localization, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        public LocalizationsController(UnitOfWork _uow, IMapper mapper) : base(_uow, mapper)
        {

        }
    }
}
