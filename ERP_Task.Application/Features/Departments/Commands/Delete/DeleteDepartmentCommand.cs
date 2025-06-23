using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Mappings;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.Delete
{
    public class DeleteDepartmentCommand : IRequest<OutputResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
