using BusinessLayer.DTOs.SaleProductDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductsController : ControllerBase
    {
        private readonly ISaleProductService _saleProductService;

        public SaleProductsController(ISaleProductService saleProductService)
        {
            _saleProductService = saleProductService;
        }

        [HttpGet("GetAllActiveSaleProducts")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _saleProductService.GetAllActiveSaleProductAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedSaleProducts")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _saleProductService.GetAllSoftDeletedSaleProduct());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSaleProductById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _saleProductService.GetByIdSaleProductAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreSaleProduct")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _saleProductService.RestoreSaleProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteSaleProduct")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _saleProductService.SoftDeleteSaleProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateSaleProduct")]

        public async Task<IActionResult> Create(SaleProductPostDTO saleProductPostDTO)
        {
            try
            {
                await _saleProductService.CreateSaleProductAsync(saleProductPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSaleProduct")]
        public async Task<IActionResult> Update(SaleProductPutDTO saleProductPutDTO)
        {
            try
            {
                await _saleProductService.UpdateSaleProductAsync(saleProductPutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSaleProduct")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _saleProductService.DeleteSaleProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
