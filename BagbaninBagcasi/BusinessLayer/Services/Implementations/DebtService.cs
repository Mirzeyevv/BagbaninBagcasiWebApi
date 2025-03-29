using AutoMapper;
using BusinessLayer.DTOs.DebtDTOs;
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

public class DebtService : IDebtService
{
    private readonly IDebtReadRepository _debtReadRepository;
    private readonly IDebtWriteRepository _debtWriteRepository;
    private readonly IMapper _mapper;


    public DebtService(IDebtReadRepository debtReadRepository, IDebtWriteRepository debtWriteRepository, IMapper mapper)
    {

        _debtReadRepository = debtReadRepository;
        _debtWriteRepository = debtWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateDebtAsync(DebtPostDTO debtPostDTO)
    {
        Debt debt = _mapper.Map<Debt>(debtPostDTO);
        debt.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _debtWriteRepository.CreateAsync(debt);
        var result = await _debtWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Debt not created");
        }
    }

    public async Task DeleteDebtAsync(Guid id)
    {
        if (!await _debtReadRepository.IsExist(id)) throw new Exception("Debt not found");
        Debt debt = await _debtReadRepository.GetByIdAsync(id) ?? throw new Exception("Debt not found");
        _debtWriteRepository.Delete(debt);

        var result = await _debtWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Debt not created");
        }
    }

    public async Task<ICollection<DebtGetDTO>> GetAllActiveDebtAsync()
    {
        ICollection<Debt> debts = await _debtReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<DebtGetDTO>>(debts);
    }

    public async Task<ICollection<DebtGetDTO>> GetAllSoftDeletedDebt()
    {
        ICollection<Debt> debts = await _debtReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<DebtGetDTO>>(debts);
    }

    public async Task<DebtGetDTO> GetByIdDebtAsync(Guid id)
    {
        if (!await _debtReadRepository.IsExist(id)) throw new Exception("Debt not found");
        Debt debt = await _debtReadRepository.GetByIdAsync(id) ?? throw new Exception("Debt not found");
        return _mapper.Map<DebtGetDTO>(debt);
    }

    public async Task RestoreDebtAsync(Guid id)
    {
        if (!await _debtReadRepository.IsExist(id)) throw new Exception("Debt not found");
        Debt debt = await _debtReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Debt not found");
        debt.IsDeleted = false;
        debt.DeletedAt = null;
        _debtWriteRepository.Update(debt);

        var result = await _debtWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Debt not created");
        }
    }

    public async Task SoftDeleteDebtAsync(Guid id)
    {
        if (!await _debtReadRepository.IsExist(id)) throw new Exception("Debt not found");
        Debt debt = await _debtReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Debt not found");
        debt.IsDeleted = true;
        debt.DeletedAt = DateTime.UtcNow.AddHours(4);
        _debtWriteRepository.Update(debt);

        var result = await _debtWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Debt not created");
        }
    }

    public async Task UpdateDebtAsync(DebtPutDTO debtPutDTO)
    {
        Debt debt = _mapper.Map<Debt>(debtPutDTO);
        debt.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _debtWriteRepository.Update(debt);

        var result = await _debtWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Debt not created");
        }
    }
}
