using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERP_Task.Application.Repositories;
using ERP_Task.Application.Responses;
using MediatR;

namespace ERP_Task.Application.Features.Departments.Commands.Delete
{
    internal class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, OutputResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IMapper _mapper;
        public DeleteDepartmentCommandHandler(IDepartmentRepository DepartmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _DepartmentRepository = DepartmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OutputResponse<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _DepartmentRepository.Get(request.Id, cancellationToken);          
            await _DepartmentRepository.DeleteAsync(Department,cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
