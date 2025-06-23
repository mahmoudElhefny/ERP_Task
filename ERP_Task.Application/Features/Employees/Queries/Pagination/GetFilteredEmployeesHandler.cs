using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Enums;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Queries.Pagination
{
    public class GetFilteredEmployeesHandler : IRequestHandler<GetFilteredEmployeesQuery, PagedResult<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetFilteredEmployeesHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EmployeeDto>> Handle(GetFilteredEmployeesQuery request, CancellationToken cancellationToken)
        {
            // Build filter
            Expression<Func<ERP_Task.Domain.Entities.Employee, bool>> filter = e =>
                (string.IsNullOrEmpty(request.Name) || e.Name.Contains(request.Name)) &&
                (!request.DepartmentId.HasValue || e.DepartmentId == request.DepartmentId) &&
                (!request.Status.HasValue || e.Status == request.Status) &&
                (!request.HireDateFrom.HasValue || e.HireDate >= request.HireDateFrom.Value) &&
                (!request.HireDateTo.HasValue || e.HireDate <= request.HireDateTo.Value);

            // Choose sort column
            Expression<Func<ERP_Task.Domain.Entities.Employee, object>>? orderBy = request.SortBy switch
            {
                EmployeeOrderBy.Name => e => e.Name,
                EmployeeOrderBy.HireDate => e => e.HireDate,
                _ => null 
            }; 

            // Get paged result from repo
            var paged = await _employeeRepository.GetPagedWithDepartmentAsync(
                request.PageNumber,
                request.PageSize,
                filter,
                orderBy,
                request.Ascending,
                cancellationToken);

            // Map to DTOs
            var dtoItems = _mapper.Map<List<EmployeeDto>>(paged.Items);

            return new PagedResult<EmployeeDto>(dtoItems, paged.TotalCount, paged.PageNumber, paged.PageSize);
        }
    }

}
