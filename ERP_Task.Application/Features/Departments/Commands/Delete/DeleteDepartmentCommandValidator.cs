using ERP_Task.Application.Repositories;
using FluentValidation;

namespace ERP_Task.Application.Features.Departments.Commands.Delete
{
    internal class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator(IDepartmentRepository _DepartmentRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .MustAsync(async (id, cancellation) => await _DepartmentRepository.ExistsAsync(e => e.Id == id, cancellation))
                .WithMessage("Department doesn't exist.");
        }
    }
}
