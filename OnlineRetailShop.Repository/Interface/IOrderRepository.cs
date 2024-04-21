using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRetailShop.Repository.Entities;

namespace OnlineRetailShop.Repository.Interface
{
    public interface IOrderRepository
    {
        Order GetById(Guid orderId);
        IEnumerable<Order> GetAll();
        //void Add(Order order);
        Task Add(Order order);
        void Update(Order order);
        void Delete(Guid orderId);
    }
}
