using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Models;
using TarGetAPI.Contexts;


namespace TarGetAPI.Controllers
{

    [Route("TarGet/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private CartContext _cartContext;


        public CartController(CartContext cartContext)
        {
            _cartContext = cartContext;
        }


        [HttpGet]
        public IEnumerable<Cart> GetCart()
        {
            return _cartContext.Cart;
        }


        [HttpGet("{Id}")]
        public Cart GetCartById(int Id)
        {
            return _cartContext.Cart.FirstOrDefault(c => c.Ct_Id == Id);
        }


        [HttpPost]
        public IActionResult PostCart([FromBody] Cart cart)
        {
            if (cart == null)
            {
                return NotFound();
            }

            _cartContext.Cart.Add(cart);
            _cartContext.SaveChanges();

            return Ok();


        }

        [HttpPut("{Id}")]
        
        public IActionResult PutCart(int Id , [FromBody] Cart cart)
        {
            var tempCart = _cartContext.Cart.FirstOrDefault(c => c.Ct_Id == Id);

            cart.Ct_Id = tempCart.Ct_Id;
            cart.Cust_Id = tempCart.Cust_Id;
            cart.Ct_note = tempCart.Ct_note;


            if (tempCart == null)
            {
                return NotFound(cart.Ct_Id);
            }

            _cartContext.Entry<Cart>(tempCart).CurrentValues.SetValues(cart);
            _cartContext.SaveChanges(true);

            return Ok();

        }


        [HttpDelete]

        public IActionResult DeleteCart(int Id)
        {
            var tempCart = _cartContext.Cart.FirstOrDefault(c => c.Ct_Id == Id);

            if(tempCart == null)
            {
                return NotFound();
            }

            _cartContext.Cart.Remove(tempCart);
            _cartContext.SaveChanges();

            return Ok();

        }





    }
}
