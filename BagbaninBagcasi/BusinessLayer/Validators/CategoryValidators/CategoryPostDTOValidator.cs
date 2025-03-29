using BusinessLayer.DTOs.CategoryDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;


namespace BusinessLayer.Validators.CategoryValidators;


public class CategoryPostDTOValidator : AbstractValidator<CategoryPostDTO>
{
    private readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const long MaxFileSizeInBytes = 2 * 1024 * 1024; // 2 MB

    public CategoryPostDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(3)
            .WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100)
            .WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");
    }

    private bool BeAValidImageType(IFormFile file)
    {
        if (file == null || string.IsNullOrEmpty(file.FileName))
            return false;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _permittedExtensions.Contains(extension);
    }
}
