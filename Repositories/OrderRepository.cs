using ApiUowPattern.Context;
using ApiUowPattern.Interfaces;
using ApiUowPattern.Models;

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
    }
}