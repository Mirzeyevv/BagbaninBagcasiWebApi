using AutoMapper;
using BusinessLayer.DTOs.SaleProductDTOs;
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

public class SaleProductService : ISaleProductService
{

    private readonly ISaleProductReadRepository _saleProductReadRepository;
    private readonly ISaleProductWriteRepository _saleProductWriteRepository;
    private readonly IMapper _mapper;


    public SaleProductService(ISaleProductReadRepository saleProductReadRepository, ISaleProductWriteRepository saleProductWriteRepository, IMapper mapper)
    {

        _saleProductReadRepository = saleProductReadRepository;
        _saleProductWriteRepository = saleProductWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateSaleProductAsync(SaleProductPostDTO saleProductPostDTO)
    {
        SaleProduct saleProduct = _mapper.Map<SaleProduct>(saleProductPostDTO);
        await _saleProductWriteRepository.CreateAsync(saleProduct);
        var result = await _saleProductWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("SaleProduct not created");
        }

    }

    public async Task DeleteSaleProductAsync(Guid id)
    {
        if (!await _saleProductReadRepository.IsExist(id)) throw new Exception("SaleProduct not found");
        SaleProduct saleProduct = await _saleProductReadRepository.GetByIdAsync(id) ?? throw new Exception("SaleProduct not found");
        _saleProductWriteRepository.Delete(saleProduct);

        var result = await _saleProductWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("SaleProduct not created");
        }
    }

    public async Task<ICollection<SaleProductGetDTO>> GetAllActiveSaleProductAsync()
    {
        ICollection<SaleProduct> saleProducts = await _saleProductReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<SaleProductGetDTO>>(saleProducts);
    }

    public async Task<ICollection<SaleProductGetDTO>> GetAllSoftDeletedSaleProduct()
    {
        ICollection<SaleProduct> saleProducts = await _saleProductReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<SaleProductGetDTO>>(saleProducts);
    }

    public async Task<SaleProductGetDTO> GetByIdSaleProductAsync(Guid id)
    {
        if (!await _saleProductReadRepository.IsExist(id)) throw new Exception("SaleProduct not found");
        SaleProduct saleProduct = await _saleProductReadRepository.GetByIdAsync(id) ?? throw new Exception("SaleProduct not found");
        return _mapper.Map<SaleProductGetDTO>(saleProduct);
    }

    public async Task RestoreSaleProductAsync(Guid id)
    {
        if (!await _saleProductReadRepository.IsExist(id)) throw new Exception("SaleProduct not found");
        SaleProduct saleProduct = await _saleProductReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("SaleProduct not found");
        saleProduct.IsDeleted = false;
        _saleProductWriteRepository.Update(saleProduct);

        var result = await _saleProductWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("SaleProduct not created");
        }
    }

    public async Task SoftDeleteSaleProductAsync(Guid id)
    {
        if (!await _saleProductReadRepository.IsExist(id)) throw new Exception("SaleProduct not found");
        SaleProduct saleProduct = await _saleProductReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("SaleProduct not found");
        saleProduct.IsDeleted = true;
        _saleProductWriteRepository.Update(saleProduct);

        var result = await _saleProductWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("SaleProduct not created");
        }
    }

    public async Task UpdateSaleProductAsync(SaleProductPutDTO saleProductPutDTO)
    {
        SaleProduct saleProduct = _mapper.Map<SaleProduct>(saleProductPutDTO);
        _saleProductWriteRepository.Update(saleProduct);

        var result = await _saleProductWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("SaleProduct not created");
        }
    }
}
