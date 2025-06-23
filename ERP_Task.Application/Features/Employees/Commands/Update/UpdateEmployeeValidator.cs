using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Employees.Commands.Update
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator(IEmployeeRepository _employeeRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .MustAsync(async (id, cancellation) => id == null|| await _employeeRepository.ExistsAsync(e=>e.Id==id,cancellation))
                .WithMessage("Employee doesn't exist.");

        }
    }
}
