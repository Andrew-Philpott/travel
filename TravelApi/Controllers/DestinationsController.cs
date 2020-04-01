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
        private readonly UserManager<ApplicationUser> _userManager;
        public DestinationsController(UserManager<ApplicationUser> userManager, IRepositoryWrapper db)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET api/destinations
        [HttpGet]
        public ActionResult<IQueryable<Destination>> Get(string searchString)
        {
            var query = (IQueryable<Destination>)_db.Destination;
            if (searchString == "review")
            {
                query = (IQueryable<Destination>)_db.Destination.GetDestinationsByReviewCountDescending();
            }
            else if (searchString == "rating")
            {
                query = (IQueryable<Destination>)_db.Destination.GetDestinationsAverageRatingDescending();
            }
            else
            {
                query = (IQueryable<Destination>)_db.Destination.GetAllDestinations();
            }
            return (IQueryable<Destination>)query;
        }

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
            return _db.Destination.FindByCondition(entry => entry.DestinationId == id).FirstOrDefault();
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
            var destination = _db.Destination.FindByCondition(entry => entry.DestinationId == id).FirstOrDefault();
            _db.Destination.Delete(destination);
            _db.Save();
        }
    }
}