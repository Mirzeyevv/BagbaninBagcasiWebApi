using BusinessLayer.DTOs.DebtDTOs;
using FluentValidation;

namespace BusinessLayer.Validators.DebtValidators;



public class DebtPostDTOValidator : AbstractValidator<DebtPostDTO>
{
    public DebtPostDTOValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.DueDate)
            .NotEmpty()
            .WithMessage("Due date is required.")
            .Must(BeAFutureDate)
            .WithMessage("Due date must be in the future.");
    }

    private bool BeAFutureDate(DateTime dueDate)
    {
        return dueDate.Date > DateTime.UtcNow.Date;
    }
}
