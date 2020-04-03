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
            return (from r in TravelApiContext.Reviews
                    join d in TravelApiContext.Destinations
                    on r.DestinationId equals d.DestinationId
                    orderby d.Country descending
                    select new Review { ReviewId = r.ReviewId, ReviewerName = r.ReviewerName, Description = r.Description, Rating = r.Rating, Destination = d });
        }

        public Review GetReviewById(int id)
        {
            return FindByCondition(Review => Review.ReviewId == id).FirstOrDefault();
        }
    }
}