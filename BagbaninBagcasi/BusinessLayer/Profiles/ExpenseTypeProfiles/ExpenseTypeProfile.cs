using AutoMapper;
using BusinessLayer.DTOs.ExpenseTypeDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.ExpenseTypeProfiles;

public class ExpenseTypeProfile : Profile
{
    public ExpenseTypeProfile()
    {
        CreateMap<ExpenseTypeGetDTO, ExpenseType>().ReverseMap();
        CreateMap<ExpenseTypePostDTO, ExpenseType>().ReverseMap();
        CreateMap<ExpenseTypePutDTO, ExpenseType>().ReverseMap();
    }
}
