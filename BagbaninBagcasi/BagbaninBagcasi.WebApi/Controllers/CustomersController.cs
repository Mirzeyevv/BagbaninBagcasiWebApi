using BusinessLayer.DTOs.CustomerDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllActiveCustomers")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                return Ok(await _customerService.GetAllActiveCustomerAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSoftDeletedCustomers")]
        public async Task<IActionResult> GetAllSoftDeleted()
        {
            try
            {
                return Ok(await _customerService.GetAllSoftDeletedCustomer());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _customerService.GetByIdCustomerAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestoreCustomer")]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _customerService.RestoreCustomerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SoftDeleteCustomer")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _customerService.SoftDeleteCustomerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateCustomer")]

        public async Task<IActionResult> Create(CustomerPostDTO customerPostDTO)
        {
            try
            {
                await _customerService.CreateCustomerAsync(customerPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Update(CustomerPutDTO customerPutDTO)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(customerPutDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCustomer")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
