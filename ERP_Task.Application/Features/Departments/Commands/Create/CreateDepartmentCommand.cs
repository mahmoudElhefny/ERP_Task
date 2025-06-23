using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Mappings;
using ERP_Task.Application.Responses;
using ERP_Task.Domain.Entities;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<OutputResponse<bool>>,IMapFrom<ERP_Task.Domain.Entities.Department>
    {
        public string Name { get; set; } = default!;     
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentCommand, ERP_Task.Domain.Entities.Department>();
        }
    }

}
