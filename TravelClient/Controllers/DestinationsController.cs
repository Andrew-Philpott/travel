using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelClient.Models;
using Newtonsoft;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;

namespace TravelClient.Controllers
{
    public class DestinationsController : Controller
    {

        public DestinationsController()
        {
        }

        public IActionResult Index()
        {
            var destinations = Destination.GetDestinations();
            return View(destinations);
        }

        public IActionResult Details(int id)
        {
            var thisPhoto = Destination.GetDetails(id);
            return View(thisPhoto);
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
            var thisPhoto = Destination.GetDetails(id);
            return View(thisPhoto);
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