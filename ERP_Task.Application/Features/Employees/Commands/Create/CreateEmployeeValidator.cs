using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using FluentValidation;

namespace ERP_Task.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty();
                //.EmailAddress();

            RuleFor(x => x.DepartmentId)
                .NotEqual(Guid.Empty)
                .WithMessage("DepartmentId is required");

            RuleFor(x => x.HireDate).NotNull().NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Hire date cannot be in the future");
        }
    }

}
