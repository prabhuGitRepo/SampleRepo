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
    public class CustomerController : ControllerBase
    {

        private readonly MyContext _myContext;

        public CustomerController(MyContext myContext)
        {
            _myContext = myContext;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _myContext.Customers ;
        }

        [HttpGet("GetCustomerOrdersByid/{id}")]
        public ActionResult<List<Order>> GetCustomerOrdersByName(int id)
        {
            var customer = _myContext.Customers
                                    .Include(c => c.Orders)
                                    .FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return customer.Orders.ToList();
        }


        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _myContext.Customers.SingleOrDefault(x=>x.CustomerId ==id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer Customer)
        {
            _myContext.Customers.Add(Customer);
            _myContext.SaveChanges();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Customer Customer)
        {
            _myContext.Customers.Update(Customer);
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
