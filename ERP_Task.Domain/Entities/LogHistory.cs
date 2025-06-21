using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Domain.Entities
{
    public class LogHistory
    {
        public Guid Id { get; set; }
        public string Action { get; set; } = default!;
        public string EntityName { get; set; } = default!;
        public Guid EntityId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Description { get; set; } = default!;
    }

}
