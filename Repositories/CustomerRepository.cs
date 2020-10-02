using System;
using System.Collections.Generic;
using System.Linq;
using ApiUowPattern.Context;
using ApiUowPattern.Interfaces;
using ApiUowPattern.Models;

namespace ApiUowPattern.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Customer obj)
        {
            _context.Customers.Add(obj);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public void Remove(Guid id)
        {
            var obj = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
            _context.Customers.Remove(obj);
        }

        public void Update(Customer obj)
        {
            _context.Customers.Update(obj); 
        }
    }
}