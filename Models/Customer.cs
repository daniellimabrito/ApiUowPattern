using System;

namespace ApiUowPattern.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }

    }
}