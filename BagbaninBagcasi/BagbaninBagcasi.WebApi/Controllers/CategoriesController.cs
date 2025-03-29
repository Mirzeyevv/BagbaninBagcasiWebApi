using BusinessLayer.DTOs.CategoryDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllActiveCategories")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _categoryService.GetAllActiveCategoryAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedCategories")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _categoryService.GetAllSoftDeletedCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _categoryService.GetByIdCategoryAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreCategory")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _categoryService.RestoreCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteCategory")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _categoryService.SoftDeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateCategory")]

        public async Task<IActionResult> Create(CategoryPostDTO categoryPostDTO)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(categoryPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Update(CategoryPutDTO categoryPutDTO)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(categoryPutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
