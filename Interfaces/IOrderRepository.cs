using System;
using System.Collections.Generic;
using ApiUowPattern.Models;

namespace ApiUowPattern.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order obj);
        void Remove(Guid id);
        void Update(Order obj);

        IEnumerable<Order> GetAll();
        Order GetById(Guid id);

    }
}