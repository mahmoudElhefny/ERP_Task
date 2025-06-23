using System.Net;
using ERP_Task.API.Setups.Bases;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Features.Employees.Commands.Delete;
using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Features.Employees.Queries.Get;
using ERP_Task.Application.Features.Employees.Queries.Pagination;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Responses.Pagination;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : CoreController
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Handler that processes the command when add employee 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("add-employee")]
        [ProducesResponseType(typeof(OutputResponse<bool>),(int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>),(int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>Create(CreateEmployeeCommand command)
        {
            var result=await _mediator.Send(command);
            return ReturnResult(result);
        }
        [HttpPost("update-employe")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return ReturnResult(result);
        }
        [HttpDelete("employee-soft-delete")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(DeleteEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return ReturnResult(result);
        }
        [ProducesResponseType(typeof(OutputResponse<PagedResult<EmployeeDto>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<PagedResult<EmployeeDto>>), (int)HttpStatusCode.BadRequest)]
        [HttpPost("filter")]
        public async Task<ActionResult<PagedResult<EmployeeDto>>> GetFilteredEmployees([FromBody] GetFilteredEmployeesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [ProducesResponseType(typeof(OutputResponse<EmployeeDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<EmployeeDto>), (int)HttpStatusCode.BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PagedResult<EmployeeDto>>> GetFilteredEmployees(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery { Id = id });
            return Ok(result);
        }

       
    }
}
