using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Employees.Commands.Delete
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, OutputResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OutputResponse<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Get(request.Id, cancellationToken);          
            await _employeeRepository.DeleteAsync(employee,cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
