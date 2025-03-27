using AutoMapper;
using BusinessLayer.DTOs.CategoryDTOs;
using BusinessLayer.Services.Abstractions;
using DAL.SqlServer.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IMapper _mapper;
   

    public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
    {

        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CategoryPostDTO categoryPostDTO)
    {
        Category category = _mapper.Map<Category>(categoryPostDTO);
        await _categoryWriteRepository.CreateAsync(category);
        var result = await _categoryWriteRepository.SaveAsync();  

        if(result == 0)
        {
            throw new Exception("Category not created");
        }

    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetByIdAsync(id) ?? throw new Exception("Category not found");
        _categoryWriteRepository.Delete(category);

        var result = await _categoryWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task<ICollection<CategoryGetDTO>> GetAllActiveCategoryAsync()
    {
        ICollection<Category> categories = await _categoryReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<CategoryGetDTO>>(categories);
    }

    public async Task<ICollection<CategoryGetDTO>> GetAllSoftDeletedCategory()
    {
        ICollection<Category> categories = await _categoryReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<CategoryGetDTO>>(categories);
    }

    public async Task<CategoryGetDTO> GetByIdCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetByIdAsync(id) ?? throw new Exception("Category not found");
        return _mapper.Map<CategoryGetDTO>(category);
    }

    public async Task RestoreCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Category not found");
        category.IsDeleted = false;
        _categoryWriteRepository.Update(category);

        var result = await _categoryWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task SoftDeleteCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Category not found");
        category.IsDeleted = true;
        _categoryWriteRepository.Update(category);
        
        var result = await _categoryWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task UpdateCategoryAsync(CategoryPutDTO categoryPutDTO)
    {
        Category category = _mapper.Map<Category>(categoryPutDTO);
        _categoryWriteRepository.Update(category);

        var result = await _categoryWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }
}
