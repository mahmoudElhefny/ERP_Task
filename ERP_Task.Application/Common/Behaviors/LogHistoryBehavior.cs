using MediatR;
using System.Security.Claims;
using System.Text.Json;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Features.Employees.Commands.Delete;
using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Repositories;
using Microsoft.AspNetCore.Http;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Features.Employees.Commands.Create;

public class LogHistoryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly ILogHistoryRepository _logHistoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogHistoryBehavior(ILogHistoryRepository logHistoryRepository, IHttpContextAccessor httpContextAccessor)
    {
        _logHistoryRepository = logHistoryRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next(); // proceed to handler

        // Only handle Create/Update/Delete Employee commands
        if (request is not CreateEmployeeCommand &&
            request is not UpdateEmployeeCommand &&
            request is not DeleteEmployeeCommand)
        {
            return response;
        }

        var httpContext = _httpContextAccessor.HttpContext;

        var user = httpContext?.User?.Identity?.Name ?? "Anonymous";
        var ip = httpContext?.Connection?.RemoteIpAddress?.ToString();
        var method = httpContext?.Request?.Method;
        var path = httpContext?.Request?.Path;

        var actionType = request switch
        {
            CreateEmployeeCommand => "Create",
            UpdateEmployeeCommand => "Update",
            DeleteEmployeeCommand => "Delete",
            _ => "Unknown"
        };
        var entityId = request switch
        {
            UpdateEmployeeCommand u => u.Id,
            DeleteEmployeeCommand d => d.Id,
            CreateEmployeeCommand when response is OutputResponse<CreateEmployeeCommandResult> r => r.Model?.Id,
           // CreateEmployeeCommand when response is OutputResponse<Guid> r => response?.GetType().GetProperty("Id")?.GetValue(request) as Guid?,
            _ => null
        };
        await _logHistoryRepository.LogAsync(
            entityName: "Employee",
            actionType: actionType,
            entityId: (Guid) entityId,
            description: $"{user} | {method} {path} | IP: {ip}"
        );

        return response;
    }
}
