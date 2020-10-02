using ApiUowPattern.Models;

namespace ApiUowPattern.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order obj);
         
    }
}