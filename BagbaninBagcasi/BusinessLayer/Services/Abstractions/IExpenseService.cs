using BusinessLayer.DTOs.ExpenseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface IExpenseService
{
    Task CreateExpenseAsync(ExpensePostDTO expensePostDTO);
    Task DeleteExpenseAsync(Guid id);
    Task SoftDeleteExpenseAsync(Guid id);
    Task RestoreExpenseAsync(Guid id);
    Task UpdateExpenseAsync(ExpensePutDTO expensePutDTO);
    Task<ICollection<ExpenseGetDTO>> GetAllSoftDeletedExpense();
    Task<ICollection<ExpenseGetDTO>> GetAllActiveExpenseAsync();
    Task<ExpenseGetDTO> GetByIdExpenseAsync(Guid id);
}
