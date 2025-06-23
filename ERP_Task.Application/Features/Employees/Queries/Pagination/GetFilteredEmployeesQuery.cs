using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Enums;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Queries.Pagination
{
    public class GetFilteredEmployeesQuery : IRequest<PagedResult<EmployeeDto>>
    {
        public string? Name { get; set; }
        public Guid? DepartmentId { get; set; }
        public Domain.Enums.EmployeeEnums.EmployeeStatus? Status { get; set; }
        public DateTime? HireDateFrom { get; set; }
        public DateTime? HireDateTo { get; set; }
        public EmployeeOrderBy SortBy { get; set; } = EmployeeOrderBy.None;
        public bool Ascending { get; set; } = true;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
