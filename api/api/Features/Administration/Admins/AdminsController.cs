using System.Threading.Tasks;
using api.Core.Services;
using api.Core.Store;
using api.Core.Store.Entities;
using api.Infrastructure.Controllers;
using api.Infrastructure.Extensions;
using api.Infrastructure.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Admins
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class AdminsController : BaseController<Admin, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        private readonly AdminService _adminService;

        public AdminsController(UnitOfWork _uow, IMapper mapper, AdminService adminService) : base(_uow, mapper)
        {
            _adminService = adminService;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<Admin>), 200)]
        public override async Task<ActionResult<ResultModel<SingleOut>>> UpdateAsync(long id, UpdateIn input)
        {
            var admin = _mapper.Map<Admin>(input);
            var updateResult = await _adminService.UpdateAsync(id, admin);
            return updateResult.AsApiResult();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<Admin>), 200)]
        public override async Task<ActionResult<ResultModel<SingleOut>>> CreateAsync(CreateIn input)
        {
            var admin = _mapper.Map<Admin>(input);
            var updateResult = await _adminService.CreateAsync(admin);
            return updateResult.AsApiResult();
        }
    }
}
