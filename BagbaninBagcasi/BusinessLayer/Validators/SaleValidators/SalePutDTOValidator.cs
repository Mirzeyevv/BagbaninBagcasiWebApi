using BusinessLayer.DTOs.SaleDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.SaleValidators;

public class SalePutDTOValidator : AbstractValidator<SalePutDTO>
{
    public SalePutDTOValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x.CustomerId)
            .NotNull().WithMessage("Customer ID is required.");

        RuleFor(x => x.PaymentType)
            .IsInEnum().WithMessage("Payment type is not valid.");
    }
}