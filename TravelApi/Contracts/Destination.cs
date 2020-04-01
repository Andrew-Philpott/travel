using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDestinationRepository : IRepositoryBase<Destination>
    {
        Destination GetDestinationById(int id);
        IQueryable<Destination> GetAllDestinations();
        IQueryable<Destination> GetDestinations(string city, string country);
        IEnumerable<Destination> GetDestinationsByCityName(string city);
        IEnumerable<Destination> GetDestinationsByCountryName(string country);
        IEnumerable<Destination> GetDestinationsByReviewCountDescending();
        IEnumerable<Destination> GetDestinationsAverageRatingDescending();

    }
}