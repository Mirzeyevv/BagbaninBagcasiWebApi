using BusinessLayer.DTOs.IdentityDTOs;
using FluentValidation;

namespace BusinessLayer.Validators.IdentityValidators;



public class LoginDTOValidator : AbstractValidator<LoginDTO>
{
    public LoginDTOValidator()
    {
        RuleFor(x => x.EmailorUsername)
            .NotEmpty().WithMessage("Email or username is required.")
            .MinimumLength(3).WithMessage("Email or username must be at least 3 characters long.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
