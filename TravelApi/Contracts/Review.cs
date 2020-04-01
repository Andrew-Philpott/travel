using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contracts
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Review GetReviewById(int id);
        IEnumerable<Review> GetAllReviews();
        IEnumerable<Review> GetReviewsByCityName(string city);
        IEnumerable<Review> GetReviewsByCountryName(string country);
        IEnumerable<Review> GetReviewsByReviewCountDescending();
        IEnumerable<Review> GetReviewsAverageRatingDescending();
    }
}