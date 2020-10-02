using ApiUowPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUowPattern.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Order> Orders {get;set;}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        {
            
        }
    }
}