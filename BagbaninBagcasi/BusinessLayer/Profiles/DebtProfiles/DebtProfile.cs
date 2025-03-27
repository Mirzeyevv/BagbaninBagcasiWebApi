using AutoMapper;
using BusinessLayer.DTOs.DebtDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.DebtProfiles;

public class DebtProfile : Profile
{
    public DebtProfile()
    {
        CreateMap<DebtGetDTO, Debt>().ReverseMap();
        CreateMap<DebtPostDTO, Debt>().ReverseMap();
        CreateMap<DebtPutDTO, Debt>().ReverseMap();
    }
}
