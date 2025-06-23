using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using ERP_Task.Application.Features.Employees.Dtos;
using ERP_Task.Application.Features.Employees.Queries.Pagination;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using ERP_Task.Application.Responses.Pagination;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Queries.Get
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery,OutputResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<OutputResponse<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeWithDepartmentNameAsync(request.Id);

            if (employee == null)
            {              
                throw new NotFoundException($"Employee with Id {request.Id} not found.");
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return new OutputResponse<EmployeeDto>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Model = employeeDto
            };
        }
    }
}
