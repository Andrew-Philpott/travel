using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
    public class ReviewsController : Controller
    {
        public ReviewsController()
        {
        }
        public IActionResult Index()
        {
            var reviews = Review.GetAll();
            return View(reviews);
        }

        public IActionResult Details(int id)
        {
            var review = Review.Get(id);
            return View(review);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            Review.Post(review);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var review = Review.Get(id);
            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            Review.Put(review);
            return RedirectToAction("Details", new { id = review.ReviewId });
        }

        public IActionResult Delete(int id)
        {
            var review = Review.Get(id);
            return View(review);
        }

        // [HttpPost, ActionName("Delete")]
        // public IActionResult DeleteConfirmed(int id)
        // {
        //     Review.Delete(id);
        //     return RedirectToAction("Index");
        // }
    }
}