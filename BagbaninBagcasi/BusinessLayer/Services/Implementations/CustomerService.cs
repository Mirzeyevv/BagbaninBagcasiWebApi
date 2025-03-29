using AutoMapper;
using BusinessLayer.DTOs.CustomerDTOs;
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

public class CustomerService : ICustomerService
{
    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;
    private readonly IMapper _mapper;


    public CustomerService(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMapper mapper)
    {

        _customerReadRepository = customerReadRepository;
        _customerWriteRepository = customerWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateCustomerAsync(CustomerPostDTO customerPostDTO)
    {
        Customer customer = _mapper.Map<Customer>(customerPostDTO);
        customer.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _customerWriteRepository.CreateAsync(customer);
        var result = await _customerWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Customer not created");
        }
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        if (!await _customerReadRepository.IsExist(id)) throw new Exception("Customer not found");
        Customer customer = await _customerReadRepository.GetByIdAsync(id) ?? throw new Exception("Customer not found");
        _customerWriteRepository.Delete(customer);

        var result = await _customerWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Customer not created");
        }
    }

    public async Task<ICollection<CustomerGetDTO>> GetAllActiveCustomerAsync()
    {
        ICollection<Customer> customers = await _customerReadRepository.GetAllByCondition(c => !c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<CustomerGetDTO>>(customers);
    }

    public async Task<ICollection<CustomerGetDTO>> GetAllSoftDeletedCustomer()
    {
        ICollection<Customer> customers = await _customerReadRepository.GetAllByCondition(c => c.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<CustomerGetDTO>>(customers);
    }

    public async Task<CustomerGetDTO> GetByIdCustomerAsync(Guid id)
    {
        if (!await _customerReadRepository.IsExist(id)) throw new Exception("Customer not found");
        Customer customer = await _customerReadRepository.GetByIdAsync(id) ?? throw new Exception("Customer not found");
        return _mapper.Map<CustomerGetDTO>(customer);
    }

    public async Task RestoreCustomerAsync(Guid id)
    {
        if (!await _customerReadRepository.IsExist(id)) throw new Exception("Customer not found");
        Customer customer = await _customerReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Customer not found");
        customer.IsDeleted = false;
        customer.DeletedAt = null;
        _customerWriteRepository.Update(customer);

        var result = await _customerWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Customer not created");
        }
    }

    public async Task SoftDeleteCustomerAsync(Guid id)
    {
        if (!await _customerReadRepository.IsExist(id)) throw new Exception("Customer not found");
        Customer customer = await _customerReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Customer not found");
        customer.IsDeleted = true;
        customer.DeletedAt = DateTime.UtcNow.AddHours(4);
        _customerWriteRepository.Update(customer);

        var result = await _customerWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Customer not created");
        }
    }

    public async Task UpdateCustomerAsync(CustomerPutDTO customerPutDTO)
    {
        Customer customer = _mapper.Map<Customer>(customerPutDTO);
        customer.LastModifiedAt = DateTime.UtcNow.AddHours(4);
        _customerWriteRepository.Update(customer);

        var result = await _customerWriteRepository.SaveAsync();

        if (result == 0)
        {
            throw new Exception("Customer not created");
        }
    }
}
