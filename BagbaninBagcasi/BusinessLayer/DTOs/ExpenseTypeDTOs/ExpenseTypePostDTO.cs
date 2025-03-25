using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ExpenseTypeDTOs;

public class ExpenseTypePostDTO
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;

 
}
