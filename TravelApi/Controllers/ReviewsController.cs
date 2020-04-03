using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelApi.Models;
using Contracts;
using TravelApi.Repository;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IRepositoryWrapper _db;
        public ReviewsController(IRepositoryWrapper db)
        {
            _db = db;
        }

        // GET api/reviews
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return _db.Review.GetAllReviews();
        }

        // GET api/reviews/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Review.GetReviewById(id);
        }

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
            var review = _db.Review.GetReviewById(id);
            _db.Review.Delete(review);
            _db.Save();
        }
    }
}