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
    }
}