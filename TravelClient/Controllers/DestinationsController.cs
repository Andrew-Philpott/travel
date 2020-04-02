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
            countries.Insert(0, new SelectListItem { Text = "", Value = "" });
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

            cities.Insert(0, new SelectListItem { Text = "", Value = "" });
            ViewBag.Cities = cities;

            return View(destinations);
        }

        [HttpGet("/destinations/reviews")]
        public IActionResult Review()
        {
            var destinations = Destination.GetByReviews();
            return View("ByRatings", destinations);
        }

        [HttpGet("/destinations/ratings")]
        public IActionResult Rating()
        {
            var destinations = Destination.GetByRatings();
            return View("ByReviews", destinations);
        }
        public IActionResult ByRatings(IEnumerable<Destination> destinations)
        {
            return View("ByRatings", destinations);
        }
        public IActionResult ByReviews(IEnumerable<Destination> destinations)
        {
            return View("ByReviews", destinations);
        }

        public IActionResult Details(int id)
        {
            var thisPhoto = Destination.GetDetails(id);
            return View(thisPhoto);
        }

        public IActionResult Query(string city, string country)
        {
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

        // [HttpPost]
        // public IActionResult DeleteConfirmed(int id)
        // {
        //     Destination.Delete(id);
        //     return RedirectToAction("Index");
        // }
    }
}