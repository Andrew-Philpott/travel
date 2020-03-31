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
using System.Text.RegularExpressions;

namespace TravelApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
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
        public ActionResult<IEnumerable<Review>> Get(string searchString)
        {
            Console.WriteLine(searchString);
            List<Review> reviews = null;
            if (searchString != null)
            {
                IQueryable<Destination> query = _db.Destinations.AsQueryable();
                string removeWhiteSpace = Regex.Replace(searchString, @"\s+", "");
                string[] filters = removeWhiteSpace.Split(",");

                for (int i = 0; i < filters.Length; i++)
                {
                    Console.WriteLine(filters[i]);
                    query.ToString();
                    if (i == 0)
                    {
                        query = query.Where(entry => entry.City == filters[0]);
                    }
                    else
                    {
                        query = query.Where(entry => entry.Country == filters[i]);
                    }
                }
                reviews = (List<Review>)(from r in _db.Reviews
                                         join d in query on r.DestinationId equals d.DestinationId
                                         select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description, DestinationId = r.DestinationId, Destination = new Destination { Country = d.Country, City = d.City } }).ToList();
            }
            else
            {
                IQueryable<Destination> query = _db.Destinations.AsQueryable();
                reviews = (List<Review>)(from r in _db.Reviews
                                         join d in query on r.DestinationId equals d.DestinationId
                                         select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description, DestinationId = r.DestinationId, Destination = new Destination { Country = d.Country, City = d.City } }).ToList();
            }
            // if (country != null)
            // {
            //     query = query.Where(entry => entry.Country == country);
            // }
            // if (city != null)
            // {
            //     query = query.Where(entry => entry.City == city);
            // }



            return View("Index", reviews);
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Review>> MostReviews()
        // {
        //     //Select destination by counting the number of
        //     //
        //     IEnumerable<Review> reviews = _db.Reviews.ToList();
        //     return View("Index", reviews);
        // }

        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            Review review = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == review.DestinationId);
            review.Destination = destination;
            return View("Details", review);
        }

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