using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelApi.Models;
using Contracts;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private IRepositoryWrapper _db;
        public DestinationsController(IRepositoryWrapper db)
        {
            _db = db;
        }

        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            return _db.Destination.GetAllDestinations().ToList();
        }

        // GET api/destinations/5
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            return _db.Destination.GetDestinationById(id);
        }

        //GET api/destinations/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Destination>> Search(string city, string country)
        {
            return _db.Destination.Query(city, country).ToList();
        }

        //Get api/destinations/ratings
        [HttpGet("ratings")]
        public ActionResult<IEnumerable<Destination>> GetDestinationsByRatings()
        {
            return _db.Destination.GetDestinationsByRatings().ToList();

        }

        //Get api/destinations/reviews
        [HttpGet("reviews")]
        public ActionResult<IEnumerable<Destination>> GetDestinationsByReviews()
        {
            return _db.Destination.GetDestinationsByReviews().ToList();

        }

        // POST api/destinations
        [HttpPost]
        public void Post([FromBody] Destination destination)
        {
            _db.Destination.Create(destination);
            _db.Save();
        }

        // PUT api/destinations/8
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Destination destination)
        {
            destination.DestinationId = id;
            _db.Destination.Update(destination);
            _db.Save();
        }

        // Delete api/destinations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var destination = _db.Destination.GetDestinationById(id);
            _db.Destination.Delete(destination);
            _db.Save();
        }
    }
}