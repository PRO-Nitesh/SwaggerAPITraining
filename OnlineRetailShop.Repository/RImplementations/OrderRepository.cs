using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.RImplementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public void Add(Order order)
        //{
        //    _context.Orders.Add(order);
        //    var gotorder = _context.Products.FindAsync(order.ProductId);
        //    gotorder.Quantity -= order.Quantity;
        //    _context.SaveChanges();
        //}
        public async Task Add(Order order)
        {
            _context.Orders.Add(order);
            var product = await _context.Products.FindAsync(order.ProductId);
            if (product != null)
            {
                product.Quantity -= order.Quantity;
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync(); // Save changes to the database
            }
        }


        public void Delete(Guid orderId)
        {
            var order = GetById(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(Guid orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
