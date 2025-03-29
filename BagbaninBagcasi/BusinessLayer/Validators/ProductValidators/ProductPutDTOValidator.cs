using BusinessLayer.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.ProductValidators;


public class ProductPutDTOValidator : AbstractValidator<ProductPutDTO>
{
    public ProductPutDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MinimumLength(2).WithMessage("Product name must be at least 2 characters long.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        RuleFor(x => x.FlowerTypeId)
            .NotNull().WithMessage("Flower type is required.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category ID is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be zero or greater.");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.");

        RuleFor(x => x.ExpiryDate)
            .Must(date => date == null || date.Value.Date > DateTime.UtcNow.Date)
            .WithMessage("Expiry date, if provided, must be a future date.");

        
    }
}