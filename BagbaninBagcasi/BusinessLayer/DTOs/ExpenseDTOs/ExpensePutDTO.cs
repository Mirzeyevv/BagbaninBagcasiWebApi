using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ExpenseDTOs;

public class ExpensePutDTO
{
    public Guid Id { get; set; }
    public Guid ExpenseTypeId { get; set; }
    public ExpenseType? ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
