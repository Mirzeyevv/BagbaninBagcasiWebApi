using AutoMapper;
using BusinessLayer.DTOs.ProductDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.ProductProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductGetDTO, Product>().ReverseMap();
        CreateMap<ProductPostDTO, Product>().ReverseMap();
        CreateMap<ProductPutDTO, Product>().ReverseMap();
    }
}
