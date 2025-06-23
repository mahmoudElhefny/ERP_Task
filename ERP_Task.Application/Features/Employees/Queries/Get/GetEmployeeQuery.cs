using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Queries.Get
{
    public class GetEmployeeQuery : IRequest<OutputResponse<EmployeeDto>>
    {
        public Guid Id { get; set; }
    }
}
