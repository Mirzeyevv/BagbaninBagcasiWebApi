using BusinessLayer.DTOs.ExpenseTypeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.ExpenseTypeValidators;


public class ExpenseTypePutDTOValidator : AbstractValidator<ExpenseTypePutDTO>
{
    public ExpenseTypePutDTOValidator()
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