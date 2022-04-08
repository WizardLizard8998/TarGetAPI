using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;




namespace TarGetAPI.Controllers
{

    [Route("TarGet/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {

        private DistrictContext _districtContext;

        public DistrictController(DistrictContext districtContext) { _districtContext = districtContext; }

        [HttpGet]
        public IEnumerable<District> GetDistrict()
        {
            return _districtContext.District;  

        }

        [HttpGet("{Id}")]
        public IActionResult GetDistrictById(int Id)
        {
            var tempDistrict = _districtContext.District.FirstOrDefault(d => d.D_Id == Id);

            if (tempDistrict == null) { return NotFound(); }

            return Ok(tempDistrict);

        }



        [HttpPost]

        public IActionResult PostDistrict([FromBody] District district)
        {
            if(district == null) { return BadRequest(); }
    
            _districtContext.District.Add(district);
            _districtContext.SaveChanges();

            return Ok();


        }


        [HttpPut("{Id}")]
        public IActionResult PutDistrict([FromBody] District district  , int id )
        {

            if (district == null) { return BadRequest(); }


            var tempDistrict = _districtContext.District.FirstOrDefault(d => d.D_Id == id);
            
            _districtContext.Entry<District>(district).CurrentValues.SetValues(district);
            _districtContext.SaveChanges(true);

            return Ok();


        }



        [HttpDelete("{Id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var tempDistrict = _districtContext.District.FirstOrDefault(d => d.D_Id == id); 

            if(tempDistrict == null) { return NotFound(); }

            _districtContext.District.Remove(tempDistrict);
            _districtContext.SaveChanges();

            return Ok();
        }





    }
}
