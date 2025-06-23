using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Employees.Commands.CreateEmployee;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateDepartmentValidator : AbstractValidator<CreateEmployeeCommand>
    {       
        public CreateDepartmentValidator(IDepartmentRepository _departmentRepository)
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().MustAsync(async(id,cancellationToken)=>await _departmentRepository.ExistsAsync(d=>d.Id==id,cancellationToken)).WithMessage("Department doesn't exist");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            
            RuleFor(x => x.Status).NotEmpty().NotNull();

            RuleFor(x => x.HireDate).NotNull().NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Hire date cannot be in the future");
        }
    }

}
