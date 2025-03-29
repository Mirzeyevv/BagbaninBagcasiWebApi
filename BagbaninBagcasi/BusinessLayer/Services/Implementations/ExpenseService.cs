using AutoMapper;
using BusinessLayer.DTOs.ExpenseDTOs;
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

public class ExpenseService : IExpenseService
{
    private readonly IExpenseReadRepository _expenseReadRepository;
    private readonly IExpenseWriteRepository _expenseWriteRepository;
    private readonly IMapper _mapper;


    public ExpenseService(IExpenseReadRepository expenseReadRepository, IExpenseWriteRepository expenseWriteRepository, IMapper mapper)
    {

        _expenseReadRepository = expenseReadRepository;
        _expenseWriteRepository = expenseWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateExpenseAsync(ExpensePostDTO expensePostDTO)
    {
        Expense expense = _mapper.Map<Expense>(expensePostDTO);
        expense.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _expenseWriteRepository.CreateAsync(expense);
        var result = await _expenseWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Expense not created");
        }
    }

    public async Task DeleteExpenseAsync(Guid id)
    {
        if (!await _expenseReadRepository.IsExist(id)) throw new Exception("Expense not found");
        Expense expense = await _expenseReadRepository.GetByIdAsync(id) ?? throw new Exception("Expense not found");
        _expenseWriteRepository.Delete(expense);

        var result = await _expenseWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Expense not created");
        }
    }

    public async Task<ICollection<ExpenseGetDTO>> GetAllActiveExpenseAsync()
    {
        ICollection<Expense> expenses = await _expenseReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ExpenseGetDTO>>(expenses);
    }

    public async Task<ICollection<ExpenseGetDTO>> GetAllSoftDeletedExpense()
    {
        ICollection<Expense> expenses = await _expenseReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ExpenseGetDTO>>(expenses);
    }

    public async Task<ExpenseGetDTO> GetByIdExpenseAsync(Guid id)
    {
        if (!await _expenseReadRepository.IsExist(id)) throw new Exception("Expense not found");
        Expense expense = await _expenseReadRepository.GetByIdAsync(id) ?? throw new Exception("Expense not found");
        return _mapper.Map<ExpenseGetDTO>(expense);
    }

    public async Task RestoreExpenseAsync(Guid id)
    {
        if (!await _expenseReadRepository.IsExist(id)) throw new Exception("Expense not found");
        Expense expense = await _expenseReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Expense not found");
        expense.IsDeleted = false;
        expense.DeletedAt = null;
        _expenseWriteRepository.Update(expense);

        var result = await _expenseWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Expense not created");
        }
    }

    public async Task SoftDeleteExpenseAsync(Guid id)
    {
        if (!await _expenseReadRepository.IsExist(id)) throw new Exception("Expense not found");
        Expense expense = await _expenseReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Expense not found");
        expense.IsDeleted = true;
        expense.DeletedAt = DateTime.UtcNow.AddHours(4);
        _expenseWriteRepository.Update(expense);

        var result = await _expenseWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Expense not created");
        }
    }

    public async Task UpdateExpenseAsync(ExpensePutDTO expensePutDTO)
    {
        Expense expense = _mapper.Map<Expense>(expensePutDTO);
        expense.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _expenseWriteRepository.Update(expense);

        var result = await _expenseWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Expense not created");
        }
    }
}
