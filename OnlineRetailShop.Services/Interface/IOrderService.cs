using OnlineRetailShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Services.Interface
{
    public interface IOrderService
    {
        Order GetOrderById(Guid orderId);
        IEnumerable<Order> GetAllOrders();
        Task<Order> AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid orderId);
    }
}
