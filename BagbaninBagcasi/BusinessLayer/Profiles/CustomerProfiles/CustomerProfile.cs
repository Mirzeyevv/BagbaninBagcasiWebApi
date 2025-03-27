using AutoMapper;
using BusinessLayer.DTOs.CustomerDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.CustomerProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerGetDTO, Customer>().ReverseMap();
        CreateMap<CustomerPostDTO, Customer>().ReverseMap();
        CreateMap<CustomerPutDTO, Customer>().ReverseMap();
    }
}
