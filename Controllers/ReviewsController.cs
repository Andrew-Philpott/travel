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
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string country, string city, string mostReviewed)
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            countries.AddRange(_db.Destinations.Select(a =>
            new SelectListItem
            {
                Value = a.Country,
                Text = a.Country
            }
            ).OrderBy(n => n.Text));
            countries.Insert(0, new SelectListItem { Text = "", Value = "" });

            ViewBag.Countries = countries;

            List<SelectListItem> cities = new List<SelectListItem>();
            countries.AddRange(_db.Destinations.Select(a =>
            new SelectListItem
            {
                Value = a.City,
                Text = a.City
            }
            ).OrderBy(n => n.Text));
            cities.Insert(0, new SelectListItem { Text = "", Value = "" });

            ViewBag.Cities = cities;

            IQueryable<Destination> query = _db.Destinations.AsQueryable();

            if (country != null)
            {
                query = query.Where(entry => entry.Country == country);
            }
            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }
            // if (rating != null)
            // {
            //     query = query.Where(entry )
            // }
            IEnumerable<Review> reviews = (IEnumerable<Review>)(from r in _db.Reviews
                                                                join d in query on r.DestinationId equals
                                                  d.DestinationId
                                                                select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description, Destination = d }).ToList();


            return View("Index", reviews);
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Review>> Get(string reviews)
        // {
        //     IEnumerable<Review> reviews = _db.Reviews.ToList();
        //     return View("Index", reviews);
        // }

        // GET api/reviews/5
        // [HttpGet("{id}")]
        // public ActionResult<Review> Get(int id)
        // {
        //     Review review = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
        //     Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == review.DestinationId);
        //     review.Destination = destination;
        //     return View("Details", review);
        // }
        [HttpGet("/create")]
        public ActionResult Create()
        {
            var destinations = _db.Destinations.ToList();

            ViewBag.DestinationId = _db.Destinations.Select(a =>
            new SelectListItem
            {
                Value = a.DestinationId.ToString(),
                Text = a.City + " (" + a.Country + ")"
            }
            );
            // ViewBag.DestinationId = new SelectList(destinations, "Destin");
            return View();
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