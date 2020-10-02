using System;
using ApiUowPattern.Interfaces;
using ApiUowPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiUowPattern.Controllers
{
    [ApiController]
    [Route("v1/orders")]   
    public class OrderController : ControllerBase
    {


        [HttpPost]
        [Route("")]
        public Order Post(
            [FromServices]ICustomerRepository customerRepository,
            [FromServices]IOrderRepository orderRepository,
            [FromServices]IUnitOfWork uow
        ){

            try
            {
                var customer = new Customer { Name = "Daniel Brito"};
                var order = new Order { TrackNumber =  new Random().Next(1, 1000).ToString(), Customer = customer  };

                customerRepository.Add(customer);
                orderRepository.Add(order);
                uow.Commit();

                return order; 
            }
            catch (System.Exception)
            {
                
                uow.Rollback();
                return null;
            }

        }


    }
}