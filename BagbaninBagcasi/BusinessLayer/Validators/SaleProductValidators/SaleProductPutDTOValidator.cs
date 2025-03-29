using BusinessLayer.DTOs.SaleProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.SaleProductValidators;


public class SaleProductPutDTOValidator : AbstractValidator<SaleProductPutDTO>
{
    public SaleProductPutDTOValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("Sale ID is required.");
    }
}