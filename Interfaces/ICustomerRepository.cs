using ApiUowPattern.Models;

namespace ApiUowPattern.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer obj);
    }
}