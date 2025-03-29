using AutoMapper;
using BusinessLayer.DTOs.IdentityDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.IdentityProfiles;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<RegisterDTO, IdentityUser>().ReverseMap()
            .ForMember(x => x.Password, opt => opt.Ignore())
            .ForMember(x => x.ConfirmPassword, opt => opt.Ignore());
    }
}
