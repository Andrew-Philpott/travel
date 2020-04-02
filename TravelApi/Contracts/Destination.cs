using TravelApi.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IDestinationRepository : IRepositoryBase<Destination>
    {
        Destination GetDestinationById(int id);
        IEnumerable<Destination> GetAllDestinations();
        IEnumerable<Destination> Query(string city, string country);
        IEnumerable<Destination> GetDestinationsByRatings();
        IEnumerable<Destination> GetDestinationsByReviews();

    }
}