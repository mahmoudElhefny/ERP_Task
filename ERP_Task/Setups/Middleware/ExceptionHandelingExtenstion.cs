using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using ERP_Task.Application.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using ValidationException = FluentValidation.ValidationException;

namespace ERP_Task.API.Setups.Middleware
{
    public static class ExceptionHandelingExtenstion
    {
        public static void UseCustomeExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    string errorText = "";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    if (exception.GetType() == typeof(FluentValidation.ValidationException))
                    {
                        var validationException = (ValidationException)exception;
                        var response = new OutputResponseForValidationFilter
                        {
                            Message = "One or more validation failures have occurred.",
                            StatusCode = HttpStatusCode.BadRequest,
                            Success = false,
                            Model = null,
                            Errors = validationException.Errors.Select(err => new ErrorModel()
                            {
                                //ErrorCode = err.ErrorCode,
                                Message = err.ErrorMessage,
                                Property = err.PropertyName
                            }).ToList()
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(errorText, Encoding.UTF8);
                    }
                    else
                    {
                        
                        string message = $" Exception Message: {exception.Message}";
                        var response = new OutputResponse<string>
                        {
                            Message = message,
                            StatusCode = HttpStatusCode.InternalServerError,
                            Success = false,
                            Model = null,
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(errorText, Encoding.UTF8);
                    }
                });
            });
        }
    }
}

