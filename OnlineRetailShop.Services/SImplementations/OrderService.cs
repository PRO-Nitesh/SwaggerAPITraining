using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Services.SImplementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void DeleteOrder(Guid orderId)
        {
            _orderRepository.Delete(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(Guid orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
