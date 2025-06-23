using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Application.Repositories
{
    public interface ILogHistoryRepository
    {
        Task LogAsync(string entityName, string actionType, Guid entityId, string? description);
    }
}
