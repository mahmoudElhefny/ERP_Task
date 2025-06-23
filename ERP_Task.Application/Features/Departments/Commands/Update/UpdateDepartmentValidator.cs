using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Departments.Commands.Update
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidator(IDepartmentRepository _DepartmentRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .MustAsync(async (id, cancellation) => await _DepartmentRepository.ExistsAsync(e=>e.Id==id,cancellation))
                .WithMessage("Department doesn't exist.");
            RuleFor(x => x.Name)
                .NotEmpty().NotNull();

        }
    }
}
