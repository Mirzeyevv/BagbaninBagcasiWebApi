using BusinessLayer.DTOs.ExpenseDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("GetAllActiveExpenses")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _expenseService.GetAllActiveExpenseAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedExpenses")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _expenseService.GetAllSoftDeletedExpense());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExpenseById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _expenseService.GetByIdExpenseAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreExpense")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _expenseService.RestoreExpenseAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteExpense")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _expenseService.SoftDeleteExpenseAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateExpense")]

        public async Task<IActionResult> Create(ExpensePostDTO expensePostDTO)
        {
            try
            {
                await _expenseService.CreateExpenseAsync(expensePostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateExpense")]
        public async Task<IActionResult> Update(ExpensePutDTO expensePutDTO)
        {
            try
            {
                await _expenseService.UpdateExpenseAsync(expensePutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteExpense")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _expenseService.DeleteExpenseAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
