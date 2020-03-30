using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Models;


using System.Security.Claims;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : Controller
    {
        private readonly TravelApiContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public DestinationsController(UserManager<ApplicationUser> userManager, TravelApiContext db)
        {
            _db = db;
            _userManager = userManager;
        }
        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            List<Destination> destinations = _db.Destinations.ToList();
            return View("Index", destinations);
        }

        // GET api/destinations/5
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
            destination.Reviews = _db.Reviews.Where(entry => entry.DestinationId == id).ToList();
            return View("Details", destination);
        }

        [Authorize]
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