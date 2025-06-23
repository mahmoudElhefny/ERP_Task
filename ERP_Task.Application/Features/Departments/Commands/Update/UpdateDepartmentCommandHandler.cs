using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using ERP_Task.Domain.Entities;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.Update
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, OutputResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository DepartmentRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _DepartmentRepository = DepartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OutputResponse<bool>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department =await _DepartmentRepository.Get(request.Id,cancellationToken);
            _mapper.Map(request, department);
            _DepartmentRepository.Update(department);
            await _unitOfWork.SaveChangesAsync();

            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
