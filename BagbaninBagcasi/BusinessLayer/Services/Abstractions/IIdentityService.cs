using BusinessLayer.DTOs.IdentityDTOs;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;


public interface IIdentityService
{
    Task<bool> RegisterAsync(RegisterDTO registerDto);
    Task<string> LoginAsync(LoginDTO loginDto);
    Task<bool> LogoutAsync();
   
}
