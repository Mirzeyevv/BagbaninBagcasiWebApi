using BusinessLayer.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface IProductService
{
    Task CreateProductAsync(ProductPostDTO productPostDTO);
    Task DeleteProductAsync(Guid id);
    Task SoftDeleteProductAsync(Guid id);
    Task RestoreProductAsync(Guid id);
    Task UpdateProductAsync(ProductPutDTO productPutDTO);
    Task<ICollection<ProductGetDTO>> GetAllSoftDeletedProduct();
    Task<ICollection<ProductGetDTO>> GetAllActiveProductAsync();
    Task<ProductGetDTO> GetByIdProductAsync(Guid id);
}
