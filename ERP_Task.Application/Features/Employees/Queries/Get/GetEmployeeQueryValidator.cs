using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Employees.Queries.Get
{
    public class GetEmployeeQueryValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public GetEmployeeQueryValidator(IEmployeeRepository _employeeRepository)
        {

            RuleFor(x => x.Id)
            .NotEmpty().NotNull()
                .MustAsync(async (id, cancellation) => id == null || await _employeeRepository.ExistsAsync(e => e.Id == id, cancellation))
                .WithMessage("Employee doesn't exist.");
        }
    }
}
