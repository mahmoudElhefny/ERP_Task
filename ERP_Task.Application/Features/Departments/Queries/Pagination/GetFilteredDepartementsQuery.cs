using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Application.Responses;
using MediatR;
using ERP_Task.Application.Features.Departments.Dtos;
using ERP_Task.Application.Enums;

namespace ERP_Task.Application.Features.Departments.Queries.Pagination
{
    public class GetFilteredDepartementsQuery : IRequest<OutputResponse<PagedResult<DepartmentDto>>>
    {
        public string? Name { get; set; }
       
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
