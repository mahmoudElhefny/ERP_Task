using ERP_Task.Application.Responses;
using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ERP_Task.API.Setups.Bases;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Features.Departments.Commands.Update;
using ERP_Task.Application.Features.Departments.Commands.Delete;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Application.Features.Departments.Dtos;
using ERP_Task.Application.Features.Departments.Queries.Pagination;

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
        [ProducesResponseType(typeof(OutputResponse<PagedResult<DepartmentDto>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<PagedResult<DepartmentDto>>), (int)HttpStatusCode.BadRequest)]
        [HttpPost("filter")]
        public async Task<ActionResult<PagedResult<DepartmentDto>>> GetFilteredEmployees([FromBody] GetFilteredDepartementsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
