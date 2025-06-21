using System.Net;
using ERP_Task.API.Setups.Bases;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Responses;
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
        [HttpPost("add-new-employee")]
        [ProducesResponseType(typeof(OutputResponse<bool>),(int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>),(int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>Create(CreateEmployeeCommand command)
        {
            var result=await _mediator.Send(command);
            return ReturnResult(result);
        }
        /// <summary>
        /// Handler that processes the command when student enroll for a course
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
    }
}
