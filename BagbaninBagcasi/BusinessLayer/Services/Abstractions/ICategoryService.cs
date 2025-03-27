using BusinessLayer.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface ICategoryService
{
    Task CreateCategoryAsync(CategoryPostDTO categoryPostDTO);
    Task DeleteCategoryAsync(Guid id);
    Task SoftDeleteCategoryAsync(Guid id);
    Task RestoreCategoryAsync(Guid id);
    Task UpdateCategoryAsync(CategoryPutDTO categoryPutDTO);
    Task<ICollection<CategoryGetDTO>> GetAllSoftDeletedCategory();
    Task<ICollection<CategoryGetDTO>> GetAllActiveCategoryAsync();
    Task<CategoryGetDTO> GetByIdCategoryAsync(Guid id);
   
}
