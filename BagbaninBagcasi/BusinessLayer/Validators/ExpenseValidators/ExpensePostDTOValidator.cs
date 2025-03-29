using BusinessLayer.DTOs.ExpenseDTOs;
using FluentValidation;


namespace BusinessLayer.Validators.ExpenseValidators;


public class ExpensePostDTOValidator : AbstractValidator<ExpensePostDTO>
{
    public ExpensePostDTOValidator()
    {
        RuleFor(x => x.ExpenseTypeId)
            .NotEmpty()
            .WithMessage("Expense type is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Date cannot be in the future.");

        RuleFor(x => x.Description)
            .MaximumLength(300)
            .WithMessage("Description must not exceed 300 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

