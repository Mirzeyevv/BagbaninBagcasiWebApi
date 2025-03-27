using AutoMapper;
using BusinessLayer.DTOs.FlowerTypeDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.FlowerTypeProfiles;

public class FlowerTypeProfile : Profile
{
    public FlowerTypeProfile()
    {
        CreateMap<FlowerTypeGetDTO, FlowerType>().ReverseMap();
        CreateMap<FlowerTypePostDTO, FlowerType>().ReverseMap();
        CreateMap<FlowerTypePutDTO, FlowerType>().ReverseMap();
    }
}

