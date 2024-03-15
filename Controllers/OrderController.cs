using EFCoreWithSwagger.Context;
using EFCoreWithSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly MyContext _myContext;

        public OrderController(MyContext myContext)
        {
            _myContext = myContext;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _myContext.Order;
        }

        [HttpGet("GetCustomerByOrderId/{orderId}")]
        public ActionResult<Customer> GetCustomerByOrderId(int customerId)
        {
            var order = _myContext.Order.Include(o => o.Customer)
                                       .FirstOrDefault(o => o.CustomerId == customerId);

            if (order == null || order.Customer == null)
            {
                return NotFound();
            }

            return order.Customer;
        }


        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _myContext.Order.SingleOrDefault(x=>x.Id ==id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _myContext.Order.Add(order);
            await _myContext.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }


        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Order Order)
        {
            _myContext.Order.Update(Order);
            _myContext.SaveChanges();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _myContext.Customers.FirstOrDefault(x=>x.CustomerId == id);
            if (item != null)
            {
                _myContext.Customers.Remove(item);
                _myContext.SaveChanges();
            }
        }
    }
}
