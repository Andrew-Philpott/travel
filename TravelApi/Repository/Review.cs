using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TravelApi.Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(TravelApiContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return FindAll()
            .OrderBy(x => x.Destination.City);
        }

        public Review GetReviewById(int id)
        {
            return FindByCondition(Review => Review.ReviewId == id).FirstOrDefault();
        }
    }
}