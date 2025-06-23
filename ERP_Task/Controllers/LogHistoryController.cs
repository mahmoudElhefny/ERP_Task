using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Features.Employees.Queries.Pagination;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Application.Responses;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ERP_Task.Application.Features.LogHistories.Dtos;
using ERP_Task.Application.Features.LogHistories.Get;

namespace ERP_Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(OutputResponse<PagedResult<LogHistoryDto>>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<PagedResult<LogHistoryDto>>), (int)HttpStatusCode.BadRequest)]
        [HttpPost("filter")]
        public async Task<ActionResult<PagedResult<LogHistoryDto>>> GetFilteredLogHistories([FromBody] GetLogHistoryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
