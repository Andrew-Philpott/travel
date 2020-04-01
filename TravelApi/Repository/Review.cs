using Contracts;
using TravelApi.Models;


namespace TravelApi.Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(TravelApiContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}