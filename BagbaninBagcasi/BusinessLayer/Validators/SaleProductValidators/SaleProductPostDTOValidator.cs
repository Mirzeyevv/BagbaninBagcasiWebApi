using BusinessLayer.DTOs.SaleProductDTOs;
using FluentValidation;


namespace BusinessLayer.Validators.SaleProductValidators;


public class SaleProductPostDTOValidator : AbstractValidator<SaleProductPostDTO>
{
    public SaleProductPostDTOValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("Sale ID is required.");
    }
}

