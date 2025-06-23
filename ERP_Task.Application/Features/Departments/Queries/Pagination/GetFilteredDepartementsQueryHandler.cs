using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Features.Employees.Queries.Pagination;
using ERP_Task.Application.Responses.Pagination;
using ERP_Task.Application.Responses;
using MediatR;
using AutoMapper;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Features.Departments.Dtos;
using ERP_Task.Application.Features.LogHistories.Dtos;
using System.Linq.Expressions;
using System.Net;

namespace ERP_Task.Application.Features.Departments.Queries.Pagination
{
    public class GetFilteredDepartementsQueryHandler : IRequestHandler<GetFilteredDepartementsQuery, OutputResponse<PagedResult<DepartmentDto>>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public GetFilteredDepartementsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<OutputResponse<PagedResult<DepartmentDto>>> Handle(GetFilteredDepartementsQuery request, CancellationToken cancellationToken)
        {
            // Build filter
            Expression<Func<ERP_Task.Domain.Entities.Department, bool>> filter = e =>
                (string.IsNullOrEmpty(request.Name) || e.Name.Contains(request.Name)) &&
                (!request.CreatedDateFrom.HasValue || e.DateCreated >= request.CreatedDateFrom.Value) &&
                (!request.CreatedDateTo.HasValue || e.DateCreated <= request.CreatedDateTo.Value);

            // Get paged result from repo
            var paged = await _departmentRepository.GetPagedAsync(
                request.PageNumber,
                request.PageSize,
                filter,
                cancellationToken);

            // Map to DTOs
            var dtoItems = _mapper.Map<List<DepartmentDto>>(paged.Items);
            return new OutputResponse<PagedResult<DepartmentDto>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Model = new PagedResult<DepartmentDto>(dtoItems, paged.TotalCount, paged.PageNumber, paged.PageSize),
            };
        }
    }
}
