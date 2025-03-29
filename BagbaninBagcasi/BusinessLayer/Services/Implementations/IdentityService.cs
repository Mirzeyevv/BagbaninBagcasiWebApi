using AutoMapper;
using BusinessLayer.DTOs.IdentityDTOs;
using BusinessLayer.ExternalServices.Abstractions;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations;


public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;
    public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        IJwtTokenService jwtTokenService, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _mapper = mapper;
    }

    public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
    {
        var newUser = _mapper.Map<IdentityUser>(registerDTO);

        var result = await _userManager.CreateAsync(newUser, registerDTO.Password);
        await _userManager.AddToRoleAsync(newUser, "Worker");
        if (!result.Succeeded) return false;

        
        string userToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
        
        return true;
    }


    public async Task<string> LoginAsync(LoginDTO loginDTO)
    {
        IdentityUser? searchedUser = await _userManager.FindByEmailAsync(loginDTO.EmailorUsername)
                               ?? await _userManager.FindByNameAsync(loginDTO.EmailorUsername);

        if (searchedUser == null)
            throw new Exception("User not found");

        bool result = await _userManager.CheckPasswordAsync(searchedUser, loginDTO.Password);
        if (!result) { throw new Exception("Username or password is wrong"); }
        string token = await _jwtTokenService.GenerateJwtToken(searchedUser);
        return token;
    }

    public async Task<bool> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return true;
    }

}
