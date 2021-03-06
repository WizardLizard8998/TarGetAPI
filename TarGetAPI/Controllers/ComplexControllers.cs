using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;


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

            var tempProducer = _complexContext.Producers.FirstOrDefault(p => p.P_UAID == UAID);

            if (Acc == null) { return NotFound(); }

            if (tempProducer == null)
            {

                var Producers = new Producers();
                Producers = producers;

                Producers.P_UAID = Acc.UA_Id;


                _complexContext.Producers.Add(Producers);

                _complexContext.SaveChanges(true);
                return Ok("new entry created");
            }

            producers.P_Id = tempProducer.P_Id;
            producers.P_UAID = Acc.UA_Id;
            _complexContext.Entry<Producers>(tempProducer).CurrentValues.SetValues(producers);




            _complexContext.SaveChanges(true);
            return Ok();


        }


        [HttpPost("/CreateCustomer/{UAID}")]
        public IActionResult CreateCustomer([FromBody] Customers customers, int UAID)
        {

            var Acc = _complexContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == UAID);



            if (Acc == null) { return NotFound(); }

            var Customer = new Customers();
            Customer = customers;


            Customer.C_UAID = Acc.UA_Id;


            _complexContext.Customers.Add(Customer);
            _complexContext.SaveChanges(true);


            return Ok();

        }


        [HttpPost("/AddProduct/{UAID}")]
        public IActionResult AddProduct([FromBody] Products products, int UAID)
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



        // producer null alamaz diyor göz at
        [HttpGet("/Search/{text}")]
        public IActionResult Search(string text)
        {
            var product = _complexContext.Products.FirstOrDefault(p => p.Pt_Name == text);

            var producer = _complexContext.Producers.FirstOrDefault(p => p.P_Name == text || p.P_Phone == text);

            var categories = _complexContext.Categories.FirstOrDefault(c => c.C_Name == text);

            if (product == null && producer == null && categories == null) { return NotFound(); }

            var res1 = JsonSerializer.Serialize(product);
            var res2 = JsonSerializer.Serialize(producer);
            var res3 = JsonSerializer.Serialize(categories);

            var finalres = res1 + res2 + res3;

            return Ok(finalres);



        }


        [HttpGet("/ComplexCart/{UAID}")]
        public IActionResult Cart(int UAID)
        {

            var customer = _complexContext.Customers.First(c => c.C_UAID == UAID);

            var tempCart = _complexContext.Cart.OrderBy(c => c.Ct_Id).LastOrDefault(c => c.Cust_Id == customer.C_Id && c.Ct_Paid == 0);

            if (tempCart == null)
            {

                Cart cart = new Cart();

                cart.Cust_Id = customer.C_Id;
                cart.Ct_Paid = 0;
                cart.Ct_note = "";

                _complexContext.Cart.Add(cart);
                _complexContext.SaveChanges(true);
                return Ok(cart);

            }

            return Ok(tempCart);
        }


        [HttpGet("/ComplexLogin/{mail}/{password}")]

        public IActionResult Login(string mail, string password)
        {
            var user = _complexContext.UserAccount.FirstOrDefault(ua => ua.UA_Email == mail && ua.UA_Password == password);
            if (user == null) { return NotFound(); }



            if (user.UA_Title == "Producer")
            {
                return Ok(_complexContext.Producers.FirstOrDefault(p => p.P_UAID == user.UA_Id));
            }

            if (user.UA_Title == "Customer")
            {
                return Ok(_complexContext.Customers.FirstOrDefault(c => c.C_UAID == user.UA_Id));
            }

            return BadRequest();


        }
    }
}
