using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.LogHistories.Dtos;
using ERP_Task.Application.Mappings;

namespace ERP_Task.Application.Features.Departments.Dtos
{
    public class DepartmentDto : IMapFrom<ERP_Task.Domain.Entities.Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ERP_Task.Domain.Entities.Department, DepartmentDto>().ReverseMap();
        }
    }
}
