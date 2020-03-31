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
using Microsoft.AspNetCore.JsonPatch;

namespace TravelApi.Controllers
{
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
                    .OrderByDescending(x => x.Count);
                Console.WriteLine();
                foreach (var item in mostReviewedDestination)
                {
                    Console.WriteLine(item.DestinationId + " " + item.Count);
                }

                query = (from mrd in _db.Destinations
                         join m in mostReviewedDestination
                         on mrd.DestinationId equals m.DestinationId
                         orderby m.Count descending
                         select new Destination { DestinationId = m.DestinationId, Country = mrd.Country, City = mrd.City }).ToList();
            }
            else if (searchString == "rating")
            {
                var ratings = _db.Reviews
                  .GroupBy(review => review.DestinationId)
                  .Select(group => new { DestinationId = group.Key, Average = (_db.Reviews.Where(x => x.DestinationId == group.Key).Average(x => x.Rating)) })
                  .OrderByDescending(x => x.Average);

                query = (from d in ratings
                         join dr in _db.Destinations on d.DestinationId equals dr.DestinationId
                         select new Destination { DestinationId = d.DestinationId, Country = dr.Country, City = dr.City }
                         ).ToList();
            }
            else
            {
                query = _db.Destinations.ToList();
            }
            return View("Index", query);
        }

        [HttpGet("/destinations/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("/destinations/edit/{id}")]
        public IActionResult Edit(int id)
        {
            Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
            return View(destination);
        }

        [AllowAnonymous]
        // GET api/destinations/5
        [HttpGet("details/{id}")]
        public ActionResult<Destination> Get(int id)
        {
            Destination destination = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
            destination.Reviews = _db.Reviews.Where(entry => entry.DestinationId == id).ToList();
            return View("Details", destination);
        }

        // POST api/destinations
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Destination destination)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            destination.User = currentUser;
            _db.Destinations.Add(destination);
            _db.SaveChanges();
            return RedirectToAction("Get");
        }

        // PUT api/destinations/5
        [HttpPatch]
        public ActionResult Patch(int id, [FromForm] JsonPatchDocument<Destination> destination)
        {
            if (destination != null)
            {
                var dest = new Destination();

                destination.ApplyTo(dest, ModelState);
                _db.Entry(dest).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Get");
            }
            return RedirectToAction("Get");
        }

        // DELETE api/destinations/5
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var destinationToDelete = await _db.Destinations.FirstOrDefaultAsync(entry => entry.DestinationId == id);

            // FirstOrDefault(entry => entry.DestinationId == id);
            _db.Destinations.Remove(destinationToDelete);
            await _db.SaveChangesAsync();
            return View("Index");
        }
    }
}