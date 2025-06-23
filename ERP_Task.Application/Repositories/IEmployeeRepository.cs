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
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee?> GetEmployeeWithDepartmentNameAsync(Guid id);
        Task<PagedResult<Employee>> GetPagedWithDepartmentAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<Employee, bool>>? predicate = null,
        Expression<Func<Employee, object>>? orderBy = null,
        bool ascending = true,
        CancellationToken cancellationToken = default);
    }
}
