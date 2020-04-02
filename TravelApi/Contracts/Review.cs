using TravelApi.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Review GetReviewById(int id);
        IEnumerable<Review> GetAllReviews();
        // IQueryable<Review> GetReviewsByCityName(string city);
        // IQueryable<Review> GetReviewsByCountryName(string country);
        // IQueryable<Review> GetReviewsByReviewCountDescending();
        // IQueryable<Review> GetReviewsAverageRatingDescending();
    }
}