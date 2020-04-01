using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;


namespace TravelApi.Repository
{
    public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
    {
        public DestinationRepository(TravelApiContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Destination> GetDestinations()
        {
            return FindAll()
            .OrderBy(x => x.City)
            .ToList();
        }
    }
}