using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Repositories;
using ERP_Task.Domain.Entities;
using ERP_Task.Persistence.Context;

namespace ERP_Task.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
                
        }

    }
}
