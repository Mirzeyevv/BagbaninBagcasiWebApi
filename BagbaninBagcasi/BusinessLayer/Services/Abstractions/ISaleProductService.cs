using BusinessLayer.DTOs.SaleProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface ISaleProductService
{
    Task CreateSaleProductAsync(SaleProductPostDTO saleProductPostDTO);
    Task DeleteSaleProductAsync(Guid id);
    Task SoftDeleteSaleProductAsync(Guid id);
    Task RestoreSaleProductAsync(Guid id);
    Task UpdateSaleProductAsync(SaleProductPutDTO saleProductPutDTO);
    Task<ICollection<SaleProductGetDTO>> GetAllSoftDeletedSaleProduct();
    Task<ICollection<SaleProductGetDTO>> GetAllActiveSaleProductAsync();
    Task<SaleProductGetDTO> GetByIdSaleProductAsync(Guid id);
}
