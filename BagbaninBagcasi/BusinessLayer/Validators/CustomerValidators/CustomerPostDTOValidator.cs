using BusinessLayer.DTOs.CustomerDTOs;
using FluentValidation;


namespace BusinessLayer.Validators.CustomerValidators;


public class CustomerPostDTOValidator : AbstractValidator<CustomerPostDTO>
{
    public CustomerPostDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .MinimumLength(2)
            .WithMessage("Customer name must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("Phone number must be valid and contain 10 to 15 digits. (e.g., +1234567890)");

        RuleFor(x => x.DebtAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Debt amount cannot be negative.");
    }
}

