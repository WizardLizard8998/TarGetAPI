using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;


namespace TarGetAPI.Controllers
{
        [Route("TarGet/[controller]")]
        [ApiController]

    public class ComplexControllers : ControllerBase
    {
        private ComplexContext _complexContext;

        public ComplexControllers(ComplexContext complexContext) { _complexContext = complexContext; }



        [HttpPost("/CreateProducer/{UAID}")]
        public IActionResult CreateProducer([FromBody] Producers producers, int UAID)
        {

            var Acc = _complexContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == UAID);

            

            if (Acc == null) { return NotFound(); }

            var Producers = new Producers();
            Producers = producers;
            
            Producers.P_UAID = Acc.UA_Id;
         

            _complexContext.Producers.Add(Producers);
            _complexContext.SaveChanges(true);


            return Ok();


        }


        [HttpPost("/CreateCustomer/{UAID}")]
        public IActionResult CreateCustomer([FromBody] Customers customers, int UAID)
        {

            var Acc = _complexContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == UAID);



            if (Acc == null) { return NotFound(); }

            var Customer= new Customers();
            Customer= customers;

            
            Customer.C_UAID= Acc.UA_Id;


            _complexContext.Customers.Add(Customer);
            _complexContext.SaveChanges(true);


            return Ok();

        }


        [HttpPost("/AddProduct/{UAID}")]
        public  IActionResult  AddProduct([FromBody] Products products , int UAID)
        {
            try
            {
               var User = _complexContext.Producers.FirstOrDefault(p => p.P_UAID == UAID);

                if (User == null) { return NotFound(); }

               
                products.P_Id = User.P_Id;

                _complexContext.Products.Add(products);

                return Ok();

            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e);
            }

            return Ok();
        }


    }
}
