using BusinessLayer.DTOs.SaleDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetAllActiveSales")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _saleService.GetAllActiveSaleAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedSales")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _saleService.GetAllSoftDeletedSale());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSaleById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _saleService.GetByIdSaleAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreSale")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _saleService.RestoreSaleAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteSale")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _saleService.SoftDeleteSaleAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateSale")]

        public async Task<IActionResult> Create(SalePostDTO salePostDTO)
        {
            try
            {
                await _saleService.CreateSaleAsync(salePostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSale")]
        public async Task<IActionResult> Update(SalePutDTO salePutDTO)
        {
            try
            {
                await _saleService.UpdateSaleAsync(salePutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSale")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _saleService.DeleteSaleAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
