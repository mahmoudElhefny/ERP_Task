using System.Linq.Expressions;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Domain.Entities;
using ERP_Task.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Task.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Employee?> GetEmployeeWithDepartmentNameAsync(Guid id)
        {
            return await _context.Employees.Include(e=>e.Department).FirstOrDefaultAsync(e=>e.Id==id);
        }
        public async Task<PagedResult<Employee>> GetPagedWithDepartmentAsync(
                        int pageNumber,
                        int pageSize,
                        Expression<Func<Employee, bool>>? predicate = null,
                        Expression<Func<Employee, object>>? orderBy = null,
                        bool ascending = true,
                        CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Employee>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            // Include Department navigation property
            query = query.Include(e => e.Department)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var totalCount = await query.CountAsync(cancellationToken);

            if (orderBy != null)
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            var items = await query              
                .ToListAsync(cancellationToken);

            return new PagedResult<Employee>(items, totalCount, pageNumber, pageSize);
        }


    }
}
