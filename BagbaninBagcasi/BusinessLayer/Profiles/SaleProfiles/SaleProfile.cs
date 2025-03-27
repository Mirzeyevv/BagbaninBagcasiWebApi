using AutoMapper;
using BusinessLayer.DTOs.SaleDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.SaleProfiles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<SaleGetDTO, Sale>().ReverseMap();
        CreateMap<SalePostDTO, Sale>().ReverseMap();
        CreateMap<SalePutDTO, Sale>().ReverseMap();
    }
}
