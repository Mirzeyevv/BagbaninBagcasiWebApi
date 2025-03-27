﻿using BusinessLayer.ExternalServices.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ExternalServices.Implementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    public JwtTokenService(IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
        _configuration = configuration;
        _roleManager = roleManager;
    }

    public async Task<string> GenerateJwtToken(IdentityUser user)
    {
        var role = await _roleManager.FindByIdAsync(user.Id)
                   ?? throw new ApplicationException("No role found");

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Role, role.Name)
        };

        SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken securityToken = new JwtSecurityToken
        (
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            signingCredentials: signingCredentials,
            claims: claims,
            expires: DateTime.Now.AddHours(1)
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
