using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Domain.Common;
using static ERP_Task.Domain.Enums.EmployeeEnums;

namespace ERP_Task.Domain.Entities
{
    public class Employee: BaseEntity,IDeletable
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public bool IsDeleted { get ; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }

}
