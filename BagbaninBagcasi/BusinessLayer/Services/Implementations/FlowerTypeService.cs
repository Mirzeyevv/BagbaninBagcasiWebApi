using AutoMapper;
using BusinessLayer.DTOs.FlowerTypeDTOs;
using BusinessLayer.Services.Abstractions;
using DAL.SqlServer.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations;

public class FlowerTypeService : IFlowerTypeService
{
    private readonly IFlowerTypeReadRepository _flowerTypeReadRepository;
    private readonly IFlowerTypeWriteRepository _flowerTypeWriteRepository;
    private readonly IMapper _mapper;


    public FlowerTypeService(IFlowerTypeReadRepository flowerTypeReadRepository, IFlowerTypeWriteRepository flowerTypeWriteRepository, IMapper mapper)
    {

        _flowerTypeReadRepository = flowerTypeReadRepository;
        _flowerTypeWriteRepository = flowerTypeWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateFlowerTypeAsync(FlowerTypePostDTO flowerTypePostDTO)
    {
        FlowerType flowerType = _mapper.Map<FlowerType>(flowerTypePostDTO);
        flowerType.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _flowerTypeWriteRepository.CreateAsync(flowerType);
        var result = await _flowerTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("FlowerType not created");
        }
    }

    public async Task DeleteFlowerTypeAsync(Guid id)
    {
        if (!await _flowerTypeReadRepository.IsExist(id)) throw new Exception("FlowerType not found");
        FlowerType flowerType = await _flowerTypeReadRepository.GetByIdAsync(id) ?? throw new Exception("FlowerType not found");
        _flowerTypeWriteRepository.Delete(flowerType);

        var result = await _flowerTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("FlowerType not created");
        }
    }

    public async Task<ICollection<FlowerTypeGetDTO>> GetAllActiveFlowerTypeAsync()
    {
        ICollection<FlowerType> flowerTypes = await _flowerTypeReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<FlowerTypeGetDTO>>(flowerTypes);
    }

    public async Task<ICollection<FlowerTypeGetDTO>> GetAllSoftDeletedFlowerType()
    {
        ICollection<FlowerType> flowerTypes = await _flowerTypeReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<FlowerTypeGetDTO>>(flowerTypes);
    }

    public async Task<FlowerTypeGetDTO> GetByIdFlowerTypeAsync(Guid id)
    {
        if (!await _flowerTypeReadRepository.IsExist(id)) throw new Exception("FlowerType not found");
        FlowerType flowerType = await _flowerTypeReadRepository.GetByIdAsync(id) ?? throw new Exception("FlowerType not found");
        return _mapper.Map<FlowerTypeGetDTO>(flowerType);
    }

    public async Task RestoreFlowerTypeAsync(Guid id)
    {
        if (!await _flowerTypeReadRepository.IsExist(id)) throw new Exception("FlowerType not found");
        FlowerType flowerType = await _flowerTypeReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("FlowerType not found");
        flowerType.IsDeleted = false;
        flowerType.DeletedAt = null;
        _flowerTypeWriteRepository.Update(flowerType);

        var result = await _flowerTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("FlowerType not created");
        }
    }

    public async Task SoftDeleteFlowerTypeAsync(Guid id)
    {
        if (!await _flowerTypeReadRepository.IsExist(id)) throw new Exception("FlowerType not found");
        FlowerType flowerType = await _flowerTypeReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("FlowerType not found");
        flowerType.IsDeleted = true;
        flowerType.DeletedAt = DateTime.UtcNow.AddHours(4);
        _flowerTypeWriteRepository.Update(flowerType);

        var result = await _flowerTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("FlowerType not created");
        }
    }

    public async Task UpdateFlowerTypeAsync(FlowerTypePutDTO flowerTypePutDTO)
    {
        FlowerType flowerType = _mapper.Map<FlowerType>(flowerTypePutDTO);
        flowerType.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _flowerTypeWriteRepository.Update(flowerType);

        var result = await _flowerTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("FlowerType not created");
        }
    }
}
