using BusinessLayer.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions;

public interface ICustomerService
{
    Task CreateCustomerAsync(CustomerPostDTO customerPostDTO);
    Task DeleteCustomerAsync(Guid id);
    Task SoftDeleteCustomerAsync(Guid id);
    Task RestoreCustomerAsync(Guid id);
    Task UpdateCustomerAsync(CustomerPutDTO customerPutDTO);
    Task<ICollection<CustomerGetDTO>> GetAllSoftDeletedCustomer();
    Task<ICollection<CustomerGetDTO>> GetAllActiveCustomerAsync();
    Task<CustomerGetDTO> GetByIdCustomerAsync(Guid id);
}
