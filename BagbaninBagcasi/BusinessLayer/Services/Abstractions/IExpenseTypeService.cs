using BusinessLayer.DTOs.ExpenseTypeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface IExpenseTypeService
{
    Task CreateExpenseTypeAsync(ExpenseTypePostDTO expenseTypePostDTO);
    Task DeleteExpenseTypeAsync(Guid id);
    Task SoftDeleteExpenseTypeAsync(Guid id);
    Task RestoreExpenseTypeAsync(Guid id);
    Task UpdateExpenseTypeAsync(ExpenseTypePutDTO expenseTypePutDTO);
    Task<ICollection<ExpenseTypeGetDTO>> GetAllSoftDeletedExpenseType();
    Task<ICollection<ExpenseTypeGetDTO>> GetAllActiveExpenseTypeAsync();
    Task<ExpenseTypeGetDTO> GetByIdExpenseTypeAsync(Guid id);
}
