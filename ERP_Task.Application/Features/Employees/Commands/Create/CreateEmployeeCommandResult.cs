using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Mappings;

namespace ERP_Task.Application.Features.Employees.Commands.Create
{
    public class CreateEmployeeCommandResult: IMapFrom<ERP_Task.Domain.Entities.Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public Domain.Enums.EmployeeEnums.EmployeeStatus Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ERP_Task.Domain.Entities.Employee, CreateEmployeeCommandResult>();
        }
    }
}
