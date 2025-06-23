using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Mappings;

namespace ERP_Task.Application.Features.Employees.Dtos
{
    public class EmployeeDto:IMapFrom<ERP_Task.Domain.Entities.Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string DepartmentName { get; set; } = default!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ERP_Task.Domain.Entities.Employee, EmployeeDto>()
                .ForMember(dest=>dest.DepartmentName,opt => opt.MapFrom(src => src.Department.Name));
        }
    }

}
