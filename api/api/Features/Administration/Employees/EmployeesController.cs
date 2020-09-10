using System.Threading.Tasks;
using api.Core.Services;
using api.Core.Store;
using api.Core.Models;
using api.Infrastructure.Controllers;
using api.Infrastructure.Extensions;
using api.Infrastructure.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Employees
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class EmployeesController : BaseController<Employee, ListOut, FilterIn, SingleOut, CreateIn, UpdateIn>
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(UnitOfWork _uow, IMapper mapper, EmployeeService employeeService) : base(_uow, mapper)
        {
            _employeeService = employeeService;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<SingleOut>), 200)]
        public override async Task<ActionResult<ResultModel<SingleOut>>> UpdateAsync(long id, UpdateIn input)
        {
            var employee = _mapper.Map<Employee>(input);
            var updateResult = await _employeeService.UpdateAsync(id, employee);
            return updateResult.AsApiResult();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<SingleOut>), 200)]
        public override async Task<ActionResult<ResultModel<SingleOut>>> CreateAsync(CreateIn input)
        {
            var employee = _mapper.Map<Employee>(input);
            var updateResult = await _employeeService.CreateAsync(employee);
            return updateResult.AsApiResult();
        }
    }
}
