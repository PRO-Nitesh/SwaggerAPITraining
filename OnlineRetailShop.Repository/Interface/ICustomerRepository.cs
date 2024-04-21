using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.RImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
