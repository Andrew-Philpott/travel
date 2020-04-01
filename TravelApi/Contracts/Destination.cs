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
        IQueryable<Destination> GetDestinationsByCityName(string city);
        IQueryable<Destination> GetDestinationsByCountryName(string country);
        IQueryable<Destination> GetDestinationsByReviewCountDescending();
        IQueryable<Destination> GetDestinationsAverageRatingDescending();

    }
}