using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Employees.Commands.Create;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using ERP_Task.Domain.Entities;
using MediatR;
using static ERP_Task.Domain.Enums.EmployeeEnums;

namespace ERP_Task.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, OutputResponse<CreateEmployeeCommandResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<OutputResponse<CreateEmployeeCommandResult>> Handle(CreateEmployeeCommand request,CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<ERP_Task.Domain.Entities.Employee>(request);
            _employeeRepository.Create(employee);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<CreateEmployeeCommandResult>(employee);
        
            return new OutputResponse<CreateEmployeeCommandResult>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Model = result,
                Message= "Employee created successfully."
            };
        }
    }

}
