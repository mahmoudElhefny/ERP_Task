using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Domain.Entities;
using ERP_Task.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Task.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        protected readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PagedResult<Department>> GetPagedAsync(
                       int pageNumber,
                       int pageSize,
                       Expression<Func<Department, bool>>? predicate = null,
                       CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Department>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .ToListAsync(cancellationToken);

            return new PagedResult<Department>(items, totalCount, pageNumber, pageSize);
        }
    }
}
