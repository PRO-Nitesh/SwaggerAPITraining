using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Services.SImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid customerId);
    }
}
