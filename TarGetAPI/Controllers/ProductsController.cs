using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;


namespace TarGetAPI.Controllers
{

    [Route("TarGet/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private ProductsContext _productsContext;

        public ProductsController(ProductsContext productsContext) { _productsContext = productsContext; }
        
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _productsContext.Products;

        }

        [HttpGet("{Id}")]

       public IActionResult GetProductsById(int Id)
        {
                var tempProducts = _productsContext.Products.FirstOrDefault(p => p.Pt_Id == Id);

            if (tempProducts == null) { return NotFound(); }

            return Ok(tempProducts);

        }


       [HttpGet("Category/{CID}")]
       public IEnumerable<Products> GetProductsBycID(int CID)
        {
            

            

            return _productsContext.Products.Where(p => p.C_Id == CID) ;

        }



        [HttpPost]
        public IActionResult PostProducts([FromBody] Products products)
        {
           

             _productsContext.Products.Add(products);
             _productsContext.SaveChanges(true);

            return Ok();

        }




        [HttpPost]
        [Route("Image/")]
        public IActionResult PostProductsforImage([FromBody] Products products)
        {
           

            _productsContext.Products.Add(products);
            _productsContext.SaveChanges(true);

            return Ok();

        }


        [HttpPut("{Id}")]
        public IActionResult PutProducts([FromBody] Products products, int id )
        {
            if(products==null) { return BadRequest(); }

            var tempProducts = _productsContext.Products.FirstOrDefault(p => p.Pt_Id == id);

            _productsContext.Entry<Products>(products).CurrentValues.SetValues(products);
            _productsContext.SaveChanges(true);

            return Ok();

        }
        

        [HttpDelete("{Id}")]
        public IActionResult DeleteProducts(int id)
        {
            var tempProducts = _productsContext.Products.FirstOrDefault(p =>p.Pt_Id == id);

            if(tempProducts == null) { return NotFound(); }

              _productsContext.Products.Remove(tempProducts);
            _productsContext.SaveChanges();

            return Ok();

        }

    }
}
