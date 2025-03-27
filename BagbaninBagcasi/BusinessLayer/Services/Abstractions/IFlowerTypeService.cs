using BusinessLayer.DTOs.FlowerTypeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface IFlowerTypeService
{
    Task CreateFlowerTypeAsync(FlowerTypePostDTO flowerTypePostDTO);
    Task DeleteFlowerTypeAsync(Guid id);
    Task SoftDeleteFlowerTypeAsync(Guid id);
    Task RestoreFlowerTypeAsync(Guid id);
    Task UpdateFlowerTypeAsync(FlowerTypePutDTO flowerTypePutDTO);
    Task<ICollection<FlowerTypeGetDTO>> GetAllSoftDeletedFlowerType();
    Task<ICollection<FlowerTypeGetDTO>> GetAllActiveFlowerTypeAsync();
    Task<FlowerTypeGetDTO> GetByIdFlowerTypeAsync(Guid id);
}
