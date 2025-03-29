using BusinessLayer.DTOs.ProductDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllActiveProducts")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _productService.GetAllActiveProductAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedProducts")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _productService.GetAllSoftDeletedProduct());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _productService.GetByIdProductAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreProduct")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _productService.RestoreProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteProduct")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _productService.SoftDeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateProduct")]

        public async Task<IActionResult> Create(ProductPostDTO productPostDTO)
        {
            try
            {
                await _productService.CreateProductAsync(productPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update(ProductPutDTO productPutDTO)
        {
            try
            {
                await _productService.UpdateProductAsync(productPutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
