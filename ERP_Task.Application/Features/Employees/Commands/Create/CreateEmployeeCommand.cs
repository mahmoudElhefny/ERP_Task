using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Enums;
using ERP_Task.Application.Features.Employees.Commands.Create;
using ERP_Task.Application.Mappings;
using ERP_Task.Application.Responses;
using ERP_Task.Domain.Entities;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<OutputResponse<CreateEmployeeCommandResult>>,IMapFrom<ERP_Task.Domain.Entities.Employee>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Guid DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public Domain.Enums.EmployeeEnums.EmployeeStatus Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeCommand, ERP_Task.Domain.Entities.Employee>();
        }
    }

}
