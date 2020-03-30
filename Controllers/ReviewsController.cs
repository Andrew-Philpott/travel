using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // GET api/reviews
        // [HttpGet]
        // public ActionResult<IEnumerable<Review>> Get()
        // {
        //     // return
        // }

        // // GET api/reviews/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return
        // }

        // POST api/reviews
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/reviews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/reviews/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}