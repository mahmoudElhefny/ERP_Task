using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Features.Employees.Commands.Delete;
using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Responses;
using MediatR;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERP_Task.API.Setups.Bases;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Features.Departments.Commands.Update;
using ERP_Task.Application.Features.Departments.Commands.Delete;

namespace ERP_Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : CoreController
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add-department")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return ReturnResult(result);
        }
        [HttpPost("update-department")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(UpdateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return ReturnResult(result);
        }
        [HttpDelete("department-soft-delete")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(DeleteDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return ReturnResult(result);
        }
    }
}
