using System;
using System.Collections.Generic;
using ApiUowPattern.Interfaces;
using ApiUowPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiUowPattern.Controllers
{
    [ApiController]
    [Route("v1/orders")]   
    public class OrderController : ControllerBase
    {

        private readonly Customer _customer;
        private readonly Order _order;

        private readonly IEnumerable<Order> _orders;


        public OrderController()
        {
            _customer = new Customer { CustomerId = Guid.NewGuid(), Name = "Daniel Brito"};
            _order = new Order { TrackNumber =  new Random().Next(1, 1000).ToString(), Customer = _customer  };

            _orders = new List<Order>(){
                new Order { OrderId = Guid.NewGuid(), TrackNumber =  new Random().Next(1, 1000).ToString(), CustomerId = _customer.CustomerId, Customer = _customer  },
                new Order { OrderId = Guid.NewGuid(), TrackNumber =  new Random().Next(1, 1000).ToString(), CustomerId = _customer.CustomerId, Customer = _customer  },
                new Order { OrderId = Guid.NewGuid(), TrackNumber =  new Random().Next(1, 1000).ToString(), CustomerId = _customer.CustomerId, Customer = _customer  },
                new Order { OrderId = Guid.NewGuid(), TrackNumber =  new Random().Next(1, 1000).ToString(), CustomerId = _customer.CustomerId, Customer = _customer  }

            };

        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Order> Get(
            [FromServices]IOrderRepository orderRepository
        )
        {
            return orderRepository.GetAll();
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Order> Post(
            [FromServices]ICustomerRepository customerRepository,
            [FromServices]IOrderRepository orderRepository,
            [FromServices]IUnitOfWork uow
        ){

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
 
                customerRepository.Add(_customer);
                orderRepository.Add(_order);
                uow.Commit();

                return _order; 
            }
            catch (System.Exception)
            {
                
                uow.Rollback();
                return null;
            }

        }

        [HttpPut("{id}")]
        [Route("")]
        public ActionResult<Order> Put(Guid id,
            [FromServices]IOrderRepository orderRepository,
            [FromServices]IUnitOfWork uow
        ){

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var obj = orderRepository.GetById(id);

            
                obj.IsDeliveried = true;
                obj.DeliveryTime = DateTime.Now;
                
                orderRepository.Update(obj);
                uow.Commit();

                return obj; 
            }
            catch (Exception ex)
            {
                var test = ex;
                uow.Rollback();
                return null;
            }

        }        

        [HttpDelete("{id}")]
        [Route("")]
        public IActionResult Delete(
            Guid id,
            [FromServices]IOrderRepository orderRepository,
            [FromServices]IUnitOfWork uow
            )
        {
            try
            {
                orderRepository.Remove(id);
                uow.Commit();
                return Ok($"Order numer {id} removed.");
            }
                catch (System.Exception)
            {
                uow.Rollback();
                return NoContent();
            }
        
        }


    }
}