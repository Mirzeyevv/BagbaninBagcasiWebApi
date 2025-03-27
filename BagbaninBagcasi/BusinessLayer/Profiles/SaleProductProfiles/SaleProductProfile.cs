using AutoMapper;
using BusinessLayer.DTOs.SaleProductDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.SaleProductProfiles;

public class SaleProductProfile : Profile
{
    public SaleProductProfile()
    {
        CreateMap<SaleProductGetDTO, SaleProduct>().ReverseMap();
        CreateMap<SaleProductPostDTO, SaleProduct>().ReverseMap();
        CreateMap<SaleProductPutDTO, SaleProduct>().ReverseMap();
    }
}

