using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
