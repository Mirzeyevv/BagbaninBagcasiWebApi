using BusinessLayer.DTOs.DebtDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface IDebtService
{
    Task CreateDebtAsync(DebtPostDTO debtPostDTO);
    Task DeleteDebtAsync(Guid id);
    Task SoftDeleteDebtAsync(Guid id);
    Task RestoreDebtAsync(Guid id);
    Task UpdateDebtAsync(DebtPutDTO debtPutDTO);
    Task<ICollection<DebtGetDTO>> GetAllSoftDeletedDebt();
    Task<ICollection<DebtGetDTO>> GetAllActiveDebtAsync();
    Task<DebtGetDTO> GetByIdDebtAsync(Guid id);
}
