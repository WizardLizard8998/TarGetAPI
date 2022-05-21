using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Models;
using TarGetAPI.Contexts;




namespace TarGetAPI.Controllers
{
    [Route("TarGet/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private CustomerContext _customerContext;
        
      

        public CustomerController(CustomerContext customerContext) { _customerContext = customerContext; }

       

        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return _customerContext.Customers;
        }

        [HttpGet("{Id}")]
        public IActionResult GetCustomerById(int Id)
        {
            var tempCustomer = _customerContext.Customers.FirstOrDefault(c => c.C_Id == Id);

            if (tempCustomer == null) { return NotFound(); }


            return Ok(tempCustomer);

        }


    

        [HttpPost]

        public IActionResult PostCustomer([FromBody] Customers customer)
        {
            if (customer == null) { return BadRequest(); }

            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
            return Ok();
        }





        [HttpPut("{Id}")]
        public IActionResult PutCustomer([FromBody] Customers customer , int id)
        {
            
            if(customer == null) { return BadRequest(); }
            
            var tempCustomer = _customerContext.Customers.FirstOrDefault(c =>c.C_Id == id); 

             _customerContext.Entry<Customers>(tempCustomer).CurrentValues.SetValues(customer);
            _customerContext.SaveChanges();

            return Ok();
                


        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteCustomer(int id)
        {
            var tempCustomer = _customerContext.Customers.FirstOrDefault(c  =>c.C_Id == id);    

            if ( tempCustomer == null) { return NotFound(); }   

            _customerContext.Customers.Remove(tempCustomer);
            _customerContext.SaveChanges();

            return Ok();

        }


    }
}
