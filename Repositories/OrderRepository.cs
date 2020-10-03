using System;
using System.Collections.Generic;
using System.Linq;
using ApiUowPattern.Context;
using ApiUowPattern.Interfaces;
using ApiUowPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUowPattern.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Order obj)
        {
            _context.Orders.Add(obj);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(customer => customer.Customer).ToList();
        }

        public Order GetById(Guid id)
        {
            var obj = _context.Orders.FirstOrDefault(x => x.OrderId == id);

            return obj;

        }

        public void Remove(Guid id)
        {
            var obj = _context.Orders.FirstOrDefault(x => x.OrderId == id);

            _context.Orders.Remove(obj);

        }

        public void Update(Order obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
           // _context.Orders.Update(obj);
        }
    }
}