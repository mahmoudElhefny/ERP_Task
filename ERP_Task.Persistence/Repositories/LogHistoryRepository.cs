using System.Linq.Expressions;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Domain.Entities;
using ERP_Task.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Task.Persistence.Repositories
{
    public class LogHistoryRepository : ILogHistoryRepository
    {
        private readonly AppDbContext _context;

        public LogHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<LogHistory>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<LogHistory, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<LogHistory>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .ToListAsync(cancellationToken);

            return new PagedResult<LogHistory>(items, totalCount, pageNumber, pageSize);

        }

        public async Task LogAsync(string entityName, string actionType, Guid entityId, string? description)
        {
            var log = new LogHistory
            {
                EntityName = entityName,
                Action = actionType,
                EntityId = entityId,
                // ChangedBy = changedBy,
                Timestamp = DateTime.UtcNow,
                Description = description
            };

            _context.Historys.Add(log);
            await _context.SaveChangesAsync();
        }
    }

}
