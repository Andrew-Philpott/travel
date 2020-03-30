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

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly TravelApiContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewsController(UserManager<ApplicationUser> userManager, TravelApiContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string country, string city)
        {
            // var reviews = (from r in _db.Reviews
            //                join d in _db.Destinations on r.DestinationId equals d.DestinationId
            //                select new { Review = r }).ToList();

            // Destination destination = 

            IQueryable<Destination> query = _db.Destinations.AsQueryable();

            if (country != null)
            {
                query = query.Where(entry => entry.Country == country);
            }
            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }

            foreach (Destination item in query)
            {
                item.Reviews = (IEnumerable<Review>)(from r in _db.Reviews
                                                     join d in item on r.DestinationId equals d.DestinationId
                                                     select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description }).ToList();

            }

            IEnumerable<Review> reviews = (from r in _db.Reviews
                                           join d in _db.Destinations on r.DestinationId equals d.DestinationId
                                           select new { Review = r }).ToList();

            IEnumerable<Review> reviews = _db.Reviews.ToList();
            return View("Index", reviews);
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Review>> Get(string reviews)
        // {
        //     IEnumerable<Review> reviews = _db.Reviews.ToList();
        //     return View("Index", reviews);
        // }

        // GET api/reviews/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            Review review = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == review.DestinationId);
            review.Destination = destination;
            return View("Details", review);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DestinationId = new SelectList(_db.Destinations, "DestinationId", "DestinationId");
            return View("Create");
        }

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