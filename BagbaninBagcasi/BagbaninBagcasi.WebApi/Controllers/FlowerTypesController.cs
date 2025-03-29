using BusinessLayer.DTOs.FlowerTypeDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerTypesController : ControllerBase
    {
        private readonly IFlowerTypeService _flowerTypeService;

        public FlowerTypesController(IFlowerTypeService flowerTypeService)
        {
            _flowerTypeService = flowerTypeService;
        }

        [HttpGet("GetAllActiveFlowerTypes")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _flowerTypeService.GetAllActiveFlowerTypeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedFlowerTypes")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _flowerTypeService.GetAllSoftDeletedFlowerType());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFlowerTypeById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _flowerTypeService.GetByIdFlowerTypeAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreFlowerType")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _flowerTypeService.RestoreFlowerTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteFlowerType")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _flowerTypeService.SoftDeleteFlowerTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateFlowerType")]

        public async Task<IActionResult> Create(FlowerTypePostDTO flowerTypePostDTO)
        {
            try
            {
                await _flowerTypeService.CreateFlowerTypeAsync(flowerTypePostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateFlowerType")]
        public async Task<IActionResult> Update(FlowerTypePutDTO flowerTypePutDTO)
        {
            try
            {
                await _flowerTypeService.UpdateFlowerTypeAsync(flowerTypePutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteFlowerType")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _flowerTypeService.DeleteFlowerTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
