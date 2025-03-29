using BusinessLayer.DTOs.IdentityDTOs;
using BusinessLayer.DTOs.SaleProductDTOs;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagbaninBagcasi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {

        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("RegisterIdentity")]

        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                await _identityService.RegisterAsync(registerDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("LoginIdentity")]

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                await _identityService.LoginAsync(loginDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
