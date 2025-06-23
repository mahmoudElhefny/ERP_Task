using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Mappings;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<OutputResponse<bool>>, IMapFrom<ERP_Task.Domain.Entities.Employee>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public Guid? DepartmentId { get; set; }
        public DateTime? HireDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeCommand, ERP_Task.Domain.Entities.Employee>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember, context) =>
                 {
                     if (srcMember == null)
                         return false;

                     if (srcMember is Guid guidValue)
                         return guidValue != Guid.Empty;

                     if (srcMember is DateTime dtValue)
                         return dtValue != default(DateTime);

                     return true;
                 }));
        }
        
    }
}
