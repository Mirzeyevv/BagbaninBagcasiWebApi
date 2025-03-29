using BusinessLayer.DTOs.ExpenseTypeDTOs;
using FluentValidation;


namespace BusinessLayer.Validators.ExpenseTypeValidators;


public class ExpenseTypePostDTOValidator : AbstractValidator<ExpenseTypePostDTO>
{
    public ExpenseTypePostDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(2)
            .WithMessage("Title must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(300)
            .WithMessage("Description must not exceed 300 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

