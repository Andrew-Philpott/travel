using Contracts;
using TravelApi.Models;

namespace TravelApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TravelApiContext _travelApiContext;
        private IReviewRepository _review;
        private IDestinationRepository _destination;

        // public IReviewRepository Review
        // {
        //     get
        //     {
        //         if (_review == null)
        //         {
        //             _review = new ReviewRepository(_travelApiContext);
        //         }

        //         return _review;
        //     }
        // }

        public IDestinationRepository Destination
        {
            get
            {
                if (_destination == null)
                {
                    _destination = new DestinationRepository(_travelApiContext);
                }

                return _destination;
            }
        }

        public RepositoryWrapper(TravelApiContext travelApiContext)
        {
            _travelApiContext = travelApiContext;
        }

        public void Save()
        {
            _travelApiContext.SaveChanges();
        }
    }
}