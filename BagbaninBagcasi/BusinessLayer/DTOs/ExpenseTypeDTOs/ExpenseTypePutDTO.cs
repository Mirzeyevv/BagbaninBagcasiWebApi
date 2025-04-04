﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ExpenseTypeDTOs;

public class ExpenseTypePutDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
