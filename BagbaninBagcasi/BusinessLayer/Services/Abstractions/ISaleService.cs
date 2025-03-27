using BusinessLayer.DTOs.SaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface ISaleService
{
    Task CreateSaleAsync(SalePostDTO salePostDTO);
    Task DeleteSaleAsync(Guid id);
    Task SoftDeleteSaleAsync(Guid id);
    Task RestoreSaleAsync(Guid id);
    Task UpdateSaleAsync(SalePutDTO salePutDTO);
    Task<ICollection<SaleGetDTO>> GetAllSoftDeletedSale();
    Task<ICollection<SaleGetDTO>> GetAllActiveSaleAsync();
    Task<SaleGetDTO> GetByIdSaleAsync(Guid id);
}
