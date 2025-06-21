using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Domain.Common;

namespace ERP_Task.Domain.Entities
{
    public class Department : BaseEntity, IDeletable
    {
        public string Name { get; set; } = default!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }

}
