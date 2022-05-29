using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;


namespace TarGetAPI.Controllers
{
    [Route("TarGet/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryContext _categoryContext;

        public CategoryController(CategoryContext categoryContext) { _categoryContext = categoryContext; }

        
        [HttpGet]
        public IEnumerable<Categories>  GetCategories()
        {

            return _categoryContext.Categories;

        }




    }
}
