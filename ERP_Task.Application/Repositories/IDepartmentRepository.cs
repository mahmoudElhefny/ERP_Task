using ERP_Task.Application.Responses.Pagination;
using System.Linq.Expressions;
using ERP_Task.Domain.Entities;

namespace ERP_Task.Application.Repositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<PagedResult<Department>> GetPagedAsync(
                          int pageNumber,
                          int pageSize,
                          Expression<Func<Department, bool>>? predicate = null,
                          CancellationToken cancellationToken = default);
    }
}
