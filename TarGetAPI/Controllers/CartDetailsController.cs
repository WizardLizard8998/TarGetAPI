using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;
using System;

namespace TarGetAPI.Controllers
{
        [Route("TarGet/[controller]")]
        [ApiController]

    public class CartDetailsController : ControllerBase
    {

        private CartDetailsContext _cartdetailsContext;

        public CartDetailsController(CartDetailsContext cartDetailsContext) { _cartdetailsContext = cartDetailsContext; } 

        [HttpGet]
        public IEnumerable<CartDetails> GetCartDetails()
        {
            return _cartdetailsContext.CartDetails;
        }


        [HttpGet("{Id}")]
        public IActionResult GetCartDetailsById(int Id)
        {

            var tempCartDetail = _cartdetailsContext.CartDetails.FirstOrDefault(cd => cd.CD_Id == Id);  

            if (tempCartDetail == null) { return NotFound(); }  

            return Ok(tempCartDetail);

        }


        [HttpGet("cart/{ctID}")]
        public IActionResult GetCartDetailsByCartId(int ctID)
        {

            var tempCartDetail = _cartdetailsContext.CartDetails.Where(cd => cd.Ct_Id == ctID);

            if (tempCartDetail == null) { return NotFound(); }

            return Ok(tempCartDetail);

        }


        [HttpPost]
        public IActionResult PostCartDetails([FromBody] CartDetails cartDetails)
        {
            if (cartDetails == null) { return BadRequest(); }

            cartDetails.CD_date = DateTime.Now.Date;
            _cartdetailsContext.CartDetails.Add(cartDetails);
            _cartdetailsContext.SaveChanges();
            return Ok();

        }


        [HttpPut("{Id}")]
        public IActionResult PutCartDetails([FromBody] CartDetails cartDetails , int id)
        {
            if(cartDetails == null) { return BadRequest(); }

            var tempCartDetails = _cartdetailsContext.CartDetails.FirstOrDefault(cd => cd.CD_Id == id);

            if (tempCartDetails == null) { return NotFound(); }
            
            _cartdetailsContext.Entry<CartDetails>(cartDetails).CurrentValues.SetValues(cartDetails);
            _cartdetailsContext.SaveChanges(true);

            return Ok();
        
        }


        [HttpDelete("{Id}")]

        public IActionResult DeleteCartDeatails(int Id)
        {
            var tempCartDetails = _cartdetailsContext.CartDetails.FirstOrDefault(cd =>cd.CD_Id == Id);

            if(tempCartDetails == null) { return NotFound(); }

            if(tempCartDetails != null)
            {
                _cartdetailsContext.CartDetails.Remove(tempCartDetails);
                _cartdetailsContext.SaveChanges();
                
                return Ok();
            }

            return NotFound();
        }


    }
}
