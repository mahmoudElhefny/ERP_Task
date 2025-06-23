using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using ERP_Task.Domain.Entities;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, OutputResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IDepartmentRepository DepartmentRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _DepartmentRepository = DepartmentRepository;
            _mapper = mapper;
        }
        public async Task<OutputResponse<bool>> Handle(CreateDepartmentCommand request,CancellationToken cancellationToken)
        {
            var Department = _mapper.Map<ERP_Task.Domain.Entities.Department>(request);
            _DepartmentRepository.Create(Department);
            await _unitOfWork.SaveChangesAsync();

            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }

}
