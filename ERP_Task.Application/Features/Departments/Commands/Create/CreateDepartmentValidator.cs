using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Application.Features.Departments.Commands.CreateDepartment;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Department.Commands.CreateDepartment
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {       
        public CreateDepartmentValidator(IDepartmentRepository _departmentRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100); 
        }
    }

}
