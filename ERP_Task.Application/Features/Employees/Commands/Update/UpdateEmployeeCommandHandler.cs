using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, OutputResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OutputResponse<bool>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =await _employeeRepository.Get(request.Id,cancellationToken);
            _mapper.Map(request, employee);
            _employeeRepository.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
