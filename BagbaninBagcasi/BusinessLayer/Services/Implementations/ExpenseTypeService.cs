using AutoMapper;
using BusinessLayer.DTOs.ExpenseTypeDTOs;
using BusinessLayer.DTOs.ExpenseTypeDTOs;
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

public class ExpenseTypeService : IExpenseTypeService
{
    private readonly IExpenseTypeReadRepository _expenseTypeReadRepository;
    private readonly IExpenseTypeWriteRepository _expenseTypeWriteRepository;
    private readonly IMapper _mapper;


    public ExpenseTypeService(IExpenseTypeReadRepository expenseTypeReadRepository, IExpenseTypeWriteRepository expenseTypeWriteRepository, IMapper mapper)
    {

        _expenseTypeReadRepository = expenseTypeReadRepository;
        _expenseTypeWriteRepository = expenseTypeWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateExpenseTypeAsync(ExpenseTypePostDTO expenseTypePostDTO)
    {
        ExpenseType expenseType = _mapper.Map<ExpenseType>(expenseTypePostDTO);
        await _expenseTypeWriteRepository.CreateAsync(expenseType);
        var result = await _expenseTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("ExpenseType not created");
        }

    }

    public async Task DeleteExpenseTypeAsync(Guid id)
    {
        if (!await _expenseTypeReadRepository.IsExist(id)) throw new Exception("ExpenseType not found");
        ExpenseType expenseType = await _expenseTypeReadRepository.GetByIdAsync(id) ?? throw new Exception("ExpenseType not found");
        _expenseTypeWriteRepository.Delete(expenseType);

        var result = await _expenseTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("ExpenseType not created");
        }
    }

    public async Task<ICollection<ExpenseTypeGetDTO>> GetAllActiveExpenseTypeAsync()
    {
        ICollection<ExpenseType> expenseTypes = await _expenseTypeReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ExpenseTypeGetDTO>>(expenseTypes);
    }

    public async Task<ICollection<ExpenseTypeGetDTO>> GetAllSoftDeletedExpenseType()
    {
        ICollection<ExpenseType> expenseTypes = await _expenseTypeReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ExpenseTypeGetDTO>>(expenseTypes);
    }

    public async Task<ExpenseTypeGetDTO> GetByIdExpenseTypeAsync(Guid id)
    {
        if (!await _expenseTypeReadRepository.IsExist(id)) throw new Exception("ExpenseType not found");
        ExpenseType expenseType = await _expenseTypeReadRepository.GetByIdAsync(id) ?? throw new Exception("ExpenseType not found");
        return _mapper.Map<ExpenseTypeGetDTO>(expenseType);
    }

    public async Task RestoreExpenseTypeAsync(Guid id)
    {
        if (!await _expenseTypeReadRepository.IsExist(id)) throw new Exception("ExpenseType not found");
        ExpenseType expenseType = await _expenseTypeReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("ExpenseType not found");
        expenseType.IsDeleted = false;
        _expenseTypeWriteRepository.Update(expenseType);

        var result = await _expenseTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("ExpenseType not created");
        }
    }

    public async Task SoftDeleteExpenseTypeAsync(Guid id)
    {
        if (!await _expenseTypeReadRepository.IsExist(id)) throw new Exception("ExpenseType not found");
        ExpenseType expenseType = await _expenseTypeReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("ExpenseType not found");
        expenseType.IsDeleted = true;
        _expenseTypeWriteRepository.Update(expenseType);

        var result = await _expenseTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("ExpenseType not created");
        }
    }

    public async Task UpdateExpenseTypeAsync(ExpenseTypePutDTO expenseTypePutDTO)
    {
        ExpenseType expenseType = _mapper.Map<ExpenseType>(expenseTypePutDTO);
        _expenseTypeWriteRepository.Update(expenseType);

        var result = await _expenseTypeWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("ExpenseType not created");
        }
    }
}
