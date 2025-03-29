using BusinessLayer.DTOs.DebtDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.DebtValidators;

public class DebtPutDTOValidator : AbstractValidator<DebtPutDTO>
{
    public DebtPutDTOValidator()
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
