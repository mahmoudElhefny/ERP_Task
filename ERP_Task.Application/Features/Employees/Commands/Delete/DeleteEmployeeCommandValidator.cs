using ERP_Task.Application.Features.Employees.Commands.Update;
using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Employees.Commands.Delete
{
    internal class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator(IEmployeeRepository _employeeRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .MustAsync(async (id, cancellation) => await _employeeRepository.ExistsAsync(e => e.Id == id, cancellation))
                .WithMessage("Employee doesn't exist.");
        }
    }
}
