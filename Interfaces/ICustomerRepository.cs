using System;
using System.Collections.Generic;
using ApiUowPattern.Models;

namespace ApiUowPattern.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer obj);
        void Remove(Guid id);

        void Update(Customer obj);

        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
    }
}