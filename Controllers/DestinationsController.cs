using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return;
        }

        // GET api/destinations/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return;
        }

        // POST api/destinations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/destinations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/destinations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}