using BusinessLayer.DTOs.FlowerTypeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators.FlowerTypeValidators;


public class FlowerTypePostDTOValidator : AbstractValidator<FlowerTypePostDTO>
{
    public FlowerTypePostDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Flower name is required.")
            .MinimumLength(2)
            .WithMessage("Flower name must be at least 2 characters long.")
            .MaximumLength(100)
            .WithMessage("Flower name must not exceed 100 characters.");

        RuleFor(x => x.Color)
            .NotEmpty()
            .WithMessage("Color is required.")
            .MaximumLength(50)
            .WithMessage("Color must not exceed 50 characters.");

        RuleFor(x => x.Season)
            .NotEmpty()
            .WithMessage("Season is required.")
            .MaximumLength(50)
            .WithMessage("Season must not exceed 50 characters.");

        RuleFor(x => x.GrowthType)
            .NotEmpty()
            .WithMessage("Growth type is required.")
            .MaximumLength(50)
            .WithMessage("Growth type must not exceed 50 characters.");
    }
}