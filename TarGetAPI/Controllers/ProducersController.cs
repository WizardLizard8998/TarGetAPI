using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;


namespace TarGetAPI.Controllers
{

    [Route("TarGet/[controller]")]
    [ApiController]

    public class ProducersController : ControllerBase
    {

        private ProducersContext _producersContext;

        public ProducersController(ProducersContext producersContext) { _producersContext = producersContext; }

        [HttpGet]

        public IEnumerable<Producers> GetProducers()
        {
            return _producersContext.Producers;

        }

        [HttpGet("{Id}")]
        public IActionResult GetProducersById(int id)
        {
            var tempProducers = _producersContext.Producers.FirstOrDefault(p => p.P_Id == id);

            if(tempProducers == null) { return NotFound(); }

            return Ok(tempProducers);

        }


        [HttpPost]
        public IActionResult PostProducers([FromBody] Producers producers)
        {
            if(producers == null) { return NotFound(); }

            _producersContext.Producers.Add(producers);
            _producersContext.SaveChanges();

            return Ok();
        }


        [HttpPut("{Id}")]
        public IActionResult PutProducers([FromBody] Producers producers, int id)
        {
            if(producers == null) { return BadRequest(); }

            var tempProducers = _producersContext.Producers.FirstOrDefault(p => p.P_Id == id);


            _producersContext.Entry<Producers>(producers).CurrentValues.SetValues(producers);
            _producersContext.SaveChanges(true);

            return Ok();

        }

         [HttpDelete("{Id}")]

         public IActionResult DeleteProducers(int id)
        {
            var tempProducers = _producersContext.Producers.FirstOrDefault(p =>p.P_Id == id);

            if( tempProducers == null) { return NotFound(); }
            
            _producersContext.Producers.Remove(tempProducers);
            _producersContext.SaveChanges(true);

            return Ok();
        }


    }
}
