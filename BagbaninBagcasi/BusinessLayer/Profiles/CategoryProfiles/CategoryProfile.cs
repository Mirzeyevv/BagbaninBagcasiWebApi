using AutoMapper;
using BusinessLayer.DTOs.CategoryDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.CategoryProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryGetDTO, Category>().ReverseMap();
        CreateMap<CategoryPostDTO, Category>().ReverseMap();
        CreateMap<CategoryPutDTO, Category>().ReverseMap();
    }
}
