using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelClient.Controllers
{
    public class DestinationsController : Controller
    {

        public DestinationsController()
        {
        }

        public IActionResult Index()
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            List<SelectListItem> cities = new List<SelectListItem>();

            IQueryable<Destination> destinations = Destination.GetDestinations().AsQueryable();

            HashSet<string> countriesArray = (from c in destinations
                                              select new string(c.Country)).ToHashSet();

            countries.AddRange(countriesArray.Select(a =>
            new SelectListItem
            {
                Value = a,
                Text = a
            }
            ).OrderBy(n => n.Text));

            ViewBag.Countries = countries;

            HashSet<string> citiesSet = (from c in destinations
                                         select new string(c.City)).ToHashSet();

            cities.AddRange(citiesSet.Select(a =>
            new SelectListItem
            {
                Value = a,
                Text = a
            }
            ).OrderBy(n => n.Text));

            ViewBag.Cities = cities;

            return View(destinations);
        }

        public IActionResult Details(int id)
        {
            var thisPhoto = Destination.GetDetails(id);
            return View(thisPhoto);
        }

        public IActionResult Search(string city, string country)
        {
            Console.WriteLine("Search:");
            // Console.WriteLine(search);
            var destinations = Destination.Search(city, country);
            return View("Search", destinations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination destination)
        {
            Destination.Post(destination);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var destination = Destination.GetDetails(id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult Edit(Destination destination)
        {
            Destination.Put(destination);
            return RedirectToAction("Details", new { id = destination.DestinationId });
        }

        public IActionResult Delete(int id)
        {
            var destination = Destination.GetDetails(id);
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Destination.Delete(id);
            return RedirectToAction("Index");
        }

        // GET api/destinations
        // [AllowAnonymous]
        // [HttpGet]
        // public ActionResult<IEnumerable<Destination>> Get(string searchString)
        // {
        //     IEnumerable<Destination> query = null;

        //     if (searchString == "review")
        //     {
        //         query = _db.Destination.GetDestinationsByReviewCountDescending();
        //     }
        //     else if (searchString == "rating")
        //     {
        //         query = _db.Destination.GetDestinationsAverageRatingDescending();
        //     }
        //     else
        //     {
        //         query = _db.Destination.GetAllDestinations();
        //     }
        //     return View("Index", query);
        // }

        // public IActionResult Create()
        // {
        //     return View();
        // }

        // public IActionResult Edit(int id)
        // {
        //     return View(_db.Destination.FindByCondition(x => x.DestinationId == id).FirstOrDefault());
        // }

        // [AllowAnonymous]
        // // GET api/destinations/5
        // [HttpGet("details/{id}")]
        // public ActionResult<Destination> Get(int id)
        // {
        //     return View("Details", _db.Destination.FindByCondition(x => x.DestinationId == id).FirstOrDefault());
        // }

        // // POST api/destinations
        // [HttpPost]
        // public async Task<ActionResult> Post(Destination destination)
        // {
        //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     var currentUser = await _userManager.FindByIdAsync(userId);
        //     destination.User = currentUser;
        //     _db.Destinations.Add(destination);
        //     _db.SaveChanges();
        //     return RedirectToAction("Get");
        // }

        // // PUT api/destinations/5
        // [HttpPatch]
        // public ActionResult Patch(int id, [FromBody] JsonPatchDocument<Destination> destination)
        // {
        //     if (destination != null)
        //     {
        //         var dest = new Destination();

        //         destination.ApplyTo(dest, ModelState);
        //         _db.Entry(dest).State = EntityState.Modified;
        //         _db.SaveChanges();
        //         return RedirectToAction("Get");
        //     }
        //     return RedirectToAction("Get");
        // }

        // DELETE api/destinations/5
        // [HttpPost, ActionName("Delete")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     Destination destinationToDelete = await _db.Destinations.FirstOrDefaultAsync(entry => entry.DestinationId == id);

        //     // FirstOrDefault(entry => entry.DestinationId == id);
        //     _db.Destinations.Remove(destinationToDelete);
        //     await _db.SaveChangesAsync();
        //     return RedirectToAction("Get");
        // }
    }
}