using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Services.Interface;
using OnlineRetailShop.Repository;
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

        //public void AddOrder(Order order)
        //{
        //    order.OrderId = Guid.NewGuid();
        //    _orderRepository.Add(order);
        //}

        public async Task<Order> AddOrder(Order order)
        {
            order.OrderId = Guid.NewGuid();
            var order1 = await _orderRepository.Add(order);
            return order1; 
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

        //void IOrderService.AddOrder(Order order)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
