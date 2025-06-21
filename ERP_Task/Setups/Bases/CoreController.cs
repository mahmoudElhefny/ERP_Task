using System.Net;
using ERP_Task.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Task.API.Setups.Bases
{
    public class CoreController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        public ObjectResult NewResult<T>(OutputResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: //200
                    return new OkObjectResult(response);
                case HttpStatusCode.Created: //201
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.BadRequest: //400
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.Unauthorized: //401
                    return new UnauthorizedObjectResult(response);               
                case HttpStatusCode.NotFound: //404
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
        public ObjectResult ReturnResult<T>(OutputResponse<T> value)
        {
            return NewResult(value);
        }
    }
}
