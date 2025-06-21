using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Domain.Entities;

namespace ERP_Task.Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}
