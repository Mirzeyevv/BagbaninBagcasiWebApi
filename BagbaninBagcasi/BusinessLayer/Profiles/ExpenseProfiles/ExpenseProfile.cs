using AutoMapper;
using BusinessLayer.DTOs.ExpenseDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles.ExpenseProfiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<ExpenseGetDTO, Expense>().ReverseMap();
        CreateMap<ExpensePostDTO, Expense>().ReverseMap();
        CreateMap<ExpensePutDTO, Expense>().ReverseMap();
    }
}
