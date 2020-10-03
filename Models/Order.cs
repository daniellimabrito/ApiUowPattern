using System;

namespace ApiUowPattern.Models
{
    public class Order
    {       
        public Guid OrderId { get; set; }
        public string TrackNumber { get; set; }
        public bool? IsDeliveried {get;set;}
        public DateTime? DeliveryTime {get;set;}
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  
    }
}