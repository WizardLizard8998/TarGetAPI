using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;


namespace TarGetAPI.Controllers
{
    [Route("TG/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private CityContext _cityContext;


        public CityController(CityContext cityContext)
        {
            _cityContext = cityContext; 
        }


        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityContext.Cities;
        }

        [HttpGet]
        [Route("{Id}")]
        public IEnumerable<City> Get(int Id)
        {
            return (IEnumerable<City>)_cityContext.Cities.FirstOrDefault(c => c.CityId == Id);
        }


        [HttpPost]
        public void Post([FromBody] City data)
        {
            if (data == null) { return; }

            _cityContext.Cities.Add(data);
            _cityContext.SaveChanges();
        }


        [HttpPut("{Name}")]
        public void Put(int Id, [FromBody] City city)
        {
            var tempcity = _cityContext.Cities.FirstOrDefault(c => c.CityId == Id);

            if(tempcity != null) 
            {
                _cityContext.Entry<City>(tempcity).CurrentValues.SetValues(city);
                _cityContext.SaveChanges();
            }


        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var tempcity = _cityContext.Cities.FirstOrDefault(c =>  c.CityId == Id);
        
            if (tempcity != null)
            {
                _cityContext.Remove(tempcity);
                _cityContext.SaveChanges();
            }
        
        }

    }
}
