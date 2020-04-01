using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;


namespace Contracts
{
    public interface IDestinationRepository : IRepositoryBase<Destination>
    {
        Destination GetDestinationById(int id);
        IEnumerable<Destination> GetAllDestinations();
        IEnumerable<Destination> GetDestinationsByCityName(string city);
        IEnumerable<Destination> GetDestinationsByCountryName(string country);
        IEnumerable<Destination> GetDestinationsByReviewCountDescending();
        IEnumerable<Destination> GetDestinationsAverageRatingDescending();

    }
}