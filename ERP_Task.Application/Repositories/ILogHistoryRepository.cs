using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Domain.Entities;

namespace ERP_Task.Application.Repositories
{
    public interface ILogHistoryRepository
    {
        Task LogAsync(string entityName, string actionType, Guid entityId, string? description);
        Task<PagedResult<LogHistory>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<LogHistory, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
    }
}
