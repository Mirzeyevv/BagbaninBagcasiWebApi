using BusinessLayer.DTOs.DebtDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtsController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtsController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("GetAllActiveDebts")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _debtService.GetAllActiveDebtAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedDebts")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _debtService.GetAllSoftDeletedDebt());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _debtService.GetByIdDebtAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreDebt")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _debtService.RestoreDebtAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteDebt")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _debtService.SoftDeleteDebtAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateDebt")]

        public async Task<IActionResult> Create(DebtPostDTO debtPostDTO)
        {
            try
            {
                await _debtService.CreateDebtAsync(debtPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateDebt")]
        public async Task<IActionResult> Update(DebtPutDTO debtPutDTO)
        {
            try
            {
                await _debtService.UpdateDebtAsync(debtPutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteDebt")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _debtService.DeleteDebtAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
