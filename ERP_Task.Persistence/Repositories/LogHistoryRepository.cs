using ERP_Task.Application.Repositories;
using ERP_Task.Domain.Entities;
using ERP_Task.Persistence.Context;
using System.Text.Json;

namespace ERP_Task.Persistence.Repositories
{
    public class LogHistoryRepository : ILogHistoryRepository
    {
        private readonly AppDbContext _context;

        public LogHistoryRepository(AppDbContext context)
        {
            _context = context;
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
                Description=description
            };

            _context.Historys.Add(log);
            await _context.SaveChangesAsync();
        }
    }

}
