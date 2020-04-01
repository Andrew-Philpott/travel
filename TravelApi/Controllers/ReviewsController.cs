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
using TravelApi.Repository;
using Contracts;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace TravelApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private IRepositoryWrapper _db;
        // private readonly UserManager<ApplicationUser> _userManager;
        public ReviewsController(IRepositoryWrapper db)
        {
            // UserManager<ApplicationUser> userManager,
            _db = db;
            // _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string searchString)
        {

            // Console.WriteLine(searchString);
            // List<Review> reviews = null;
            // if (searchString != null)
            // {
            //     IQueryable<Destination> query = _db.Destinations.AsQueryable();
            //     string[] filters = searchString.Split(",").Select(x => x.Trim()).ToArray();
            //     if (filters.Length == 2)
            //     {
            //         query = query.Where(entry => entry.City == filters[0] && entry.Country == filters[1]);
            //     }
            //     else
            //     {
            //         query = query.Where(entry => entry.City == filters[0]);
            //         if (query.Count() == 0)
            //         {
            //             query = _db.Destinations.Where(entry => entry.Country == filters[0]);
            //         }
            //     }
            //     reviews = (List<Review>)(from r in _db.Reviews
            //                              join d in query on r.DestinationId equals d.DestinationId
            //                              select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description, DestinationId = r.DestinationId, Destination = new Destination { Country = d.Country, City = d.City } }).ToList();
            // }
            // else
            // {
            //     IQueryable<Destination> query = _db.Destinations.AsQueryable();
            //     reviews = (List<Review>)(from r in _db.Reviews
            //                              join d in query on r.DestinationId equals d.DestinationId
            //                              select new Review { ReviewerName = r.ReviewerName, Rating = r.Rating, Description = r.Description, DestinationId = r.DestinationId, Destination = new Destination { Country = d.Country, City = d.City } }).ToList();
            // }
            return _db.Review.GetAllReviews().ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Review.GetReviewById(id);
        }

        // [HttpGet("/create")]
        // public ActionResult Create()
        // {
        //     // var destinations = _db.Destinations.ToList();

        //     // ViewBag.DestinationId = _db.Destinations.Select(a =>
        //     // new SelectListItem
        //     // {
        //     //     Value = a.DestinationId.ToString(),
        //     //     Text = a.City + " (" + a.Country + ")"
        //     // }
        //     // );
        //     // ViewBag.DestinationId = new SelectList(destinations, "Destin");
        //     return _db.Review.Create()
        // }

        // POST api/reviews
        [HttpPost]
        public void Post([FromForm] Review review)
        {
            _db.Review.Create(review);
            _db.Save();
        }

        // PUT api/reviews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review)
        {
            review.ReviewId = id;
            _db.Review.Update(review);
            _db.Save();
        }

        // DELETE api/reviews/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Review review = _db.Review.GetReviewById(id);
            _db.Review.Delete(review);
            _db.Save();
        }
    }
}