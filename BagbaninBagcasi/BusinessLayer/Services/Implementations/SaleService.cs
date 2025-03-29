using AutoMapper;
using BusinessLayer.DTOs.SaleDTOs;
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

public class SaleService : ISaleService
{
    private readonly ISaleReadRepository _saleReadRepository;
    private readonly ISaleWriteRepository _saleWriteRepository;
    private readonly IMapper _mapper;


    public SaleService(ISaleReadRepository saleReadRepository, ISaleWriteRepository saleWriteRepository, IMapper mapper)
    {

        _saleReadRepository = saleReadRepository;
        _saleWriteRepository = saleWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateSaleAsync(SalePostDTO salePostDTO)
    {
        Sale sale = _mapper.Map<Sale>(salePostDTO);
        sale.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _saleWriteRepository.CreateAsync(sale);
        var result = await _saleWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Sale not created");
        }
    }

    public async Task DeleteSaleAsync(Guid id)
    {
        if (!await _saleReadRepository.IsExist(id)) throw new Exception("Sale not found");
        Sale sale = await _saleReadRepository.GetByIdAsync(id) ?? throw new Exception("Sale not found");
        _saleWriteRepository.Delete(sale);

        var result = await _saleWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Sale not created");
        }
    }

    public async Task<ICollection<SaleGetDTO>> GetAllActiveSaleAsync()
    {
        ICollection<Sale> sales = await _saleReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<SaleGetDTO>>(sales);
    }

    public async Task<ICollection<SaleGetDTO>> GetAllSoftDeletedSale()
    {
        ICollection<Sale> sales = await _saleReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<SaleGetDTO>>(sales);
    }

    public async Task<SaleGetDTO> GetByIdSaleAsync(Guid id)
    {
        if (!await _saleReadRepository.IsExist(id)) throw new Exception("Sale not found");
        Sale sale = await _saleReadRepository.GetByIdAsync(id) ?? throw new Exception("Sale not found");
        return _mapper.Map<SaleGetDTO>(sale);
    }

    public async Task RestoreSaleAsync(Guid id)
    {
        if (!await _saleReadRepository.IsExist(id)) throw new Exception("Sale not found");
        Sale sale = await _saleReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Sale not found");
        sale.IsDeleted = false;
        sale.DeletedAt = null;
        _saleWriteRepository.Update(sale);

        var result = await _saleWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Sale not created");
        }
    }

    public async Task SoftDeleteSaleAsync(Guid id)
    {
        if (!await _saleReadRepository.IsExist(id)) throw new Exception("Sale not found");
        Sale sale = await _saleReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Sale not found");
        sale.IsDeleted = true;
        sale.DeletedAt = DateTime.UtcNow.AddHours(4);
        _saleWriteRepository.Update(sale);

        var result = await _saleWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Sale not created");
        }
    }

    public async Task UpdateSaleAsync(SalePutDTO salePutDTO)
    {
        Sale sale = _mapper.Map<Sale>(salePutDTO);
        sale.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _saleWriteRepository.Update(sale);

        var result = await _saleWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Sale not created");
        }
    }
}
