using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApi.Models;
using Newtonsoft;
using System.Text.RegularExpressions;
using TravelApi.Repository;
using Contracts;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private IRepositoryWrapper _db;
        // private readonly UserManager<ApplicationUser> _userManager;
        public DestinationsController(IRepositoryWrapper db)
        {
            // UserManager<ApplicationUser> userManager,
            _db = db;
            // _userManager = userManager;
        }

        // GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get(string city, string country)
        {
            if ((city == null) && (country == null))
            {
                return _db.Destination.GetDestinations(city, country).ToList();
            }
            else
            {
                return _db.Destination.FindAll().ToList();
            }
            // IQueryable destinations = _db.Destination.GetAllDestinations();
            // if (city != null && country != null)
            // {
            //     return destinations.
            // }

            // destinations.
            // if (searchString == "review")
            // {
            //     return _db.Destination.GetDestinationsByReviewCountDescending().ToList();
            // }
            // else if (searchString == "rating")
            // {
            //     return _db.Destination.GetDestinationsAverageRatingDescending().ToList();
            // }
            // else
            // {
            //     return _db.Destination.GetAllDestinations().ToList();
            // }
        }
        // [HttpGet]
        // public ActionResult<IEnumerable<Destination>> Search(string city, string country)
        // {
        //     Console.WriteLine(searchString + " search string in api search");
        //     // var query = Queryable.AsQueryable(_db.Destination);
        //     if (searchString == "review")
        //     {
        //         return _db.Destination.GetDestinationsByReviewCountDescending().ToList();
        //     }
        //     else if (searchString == "rating")
        //     {
        //         return _db.Destination.GetDestinationsAverageRatingDescending().ToList();
        //     }
        //     else
        //     {
        //         return _db.Destination.GetAllDestinations().ToList();
        //     }
        // }
        // POST api/destinations
        [HttpPost]
        public void Post([FromBody] Destination destination)
        {
            _db.Destination.Create(destination);
            _db.Save();
        }

        // GET api/destinations/5
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            return _db.Destination.GetDestinationById(id);
        }

        // PUT api/destinations/8
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Destination destination)
        {
            destination.DestinationId = id;
            _db.Destination.Update(destination);
            _db.Save();
        }

        // Delete api/destinations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Destination destination = _db.Destination.GetDestinationById(id);
            _db.Destination.Delete(destination);
            _db.Save();
        }
    }
}