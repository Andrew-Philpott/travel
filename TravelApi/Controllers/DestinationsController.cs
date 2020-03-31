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
using System.Text.RegularExpressions;

namespace TravelApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get(string searchString)
        {
            IEnumerable<Destination> query = null;

            if (searchString == "review")
            {
                var mostReviewedDestination = _db.Reviews
                    .GroupBy(review => review.DestinationId)
                    .Select(group => new { DestinationId = group.Key, Count = group.Count() })
                    .OrderByDescending(x => x.DestinationId);

                query = (from mrd in mostReviewedDestination
                         join m in _db.Destinations
on mrd.DestinationId equals m.DestinationId
                         select new Destination { DestinationId = m.DestinationId, Country = m.Country, City = m.City }).ToList();

                return View("MostReviewed", query);
            }
            else if (searchString == "rating")
            {

            }

            query = _db.Destinations.ToList();
            return View("Index", query);
        }

        // [AllowAnonymous]
        // [HttpGet("mostreviewed")]
        // public ActionResult<IEnumerable<Destination>> HighestRated()
        // {
        //     var mostReviewedDestination = _db.Reviews
        //         .GroupBy(review => review.DestinationId)
        //         .Select(group => new { DestinationId = group.Key, Count = group.Count() })
        //         .OrderBy(x => x.DestinationId)
        //         .FirstOrDefault();

        //     Destination destination = _db.Destinations.FirstOrDefault(n => n.DestinationId == mostReviewedDestination.DestinationId);

        //     List<Review> reviews = _db.Reviews.Where(entry => entry.DestinationId == destination.DestinationId).ToList();

        //     destination.Reviews = reviews;

        //     return View("Details", destination);
        // }


        [AllowAnonymous]
        // GET api/destinations/5
        [HttpGet("details/{id}")]
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