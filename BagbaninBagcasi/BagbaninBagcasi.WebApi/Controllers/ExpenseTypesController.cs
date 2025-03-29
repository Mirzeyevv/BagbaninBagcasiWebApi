using BusinessLayer.DTOs.ExpenseTypeDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypesController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

        [HttpGet("GetAllActiveExpenseTypes")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _expenseTypeService.GetAllActiveExpenseTypeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedExpenseTypes")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _expenseTypeService.GetAllSoftDeletedExpenseType());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExpenseTypeById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _expenseTypeService.GetByIdExpenseTypeAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreExpenseType")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _expenseTypeService.RestoreExpenseTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteExpenseType")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _expenseTypeService.SoftDeleteExpenseTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateExpenseType")]

        public async Task<IActionResult> Create(ExpenseTypePostDTO expenseTypePostDTO)
        {
            try
            {
                await _expenseTypeService.CreateExpenseTypeAsync(expenseTypePostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateExpenseType")]
        public async Task<IActionResult> Update(ExpenseTypePutDTO expenseTypePutDTO)
        {
            try
            {
                await _expenseTypeService.UpdateExpenseTypeAsync(expenseTypePutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteExpenseType")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _expenseTypeService.DeleteExpenseTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
