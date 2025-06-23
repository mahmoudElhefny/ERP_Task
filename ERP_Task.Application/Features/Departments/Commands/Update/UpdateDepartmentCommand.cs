using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Mappings;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.Update
{
    public class UpdateDepartmentCommand : IRequest<OutputResponse<bool>>, IMapFrom<ERP_Task.Domain.Entities.Department>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentCommand, ERP_Task.Domain.Entities.Department>().ForAllMembers(opts => opts.Condition((src, dest, srcMember, context) =>
            {
                if (srcMember == null)
                    return false;

                if (srcMember is Guid guidValue)
                    return guidValue != Guid.Empty;

                if (srcMember is DateTime dtValue)
                    return dtValue != default(DateTime);

                return true;
            })); ;
        }
        
    }
}
