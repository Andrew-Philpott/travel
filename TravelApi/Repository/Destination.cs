using Contracts;
using TravelApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TravelApi.Repository
{
    public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
    {

        public DestinationRepository(TravelApiContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Destination> Query(string city, string country)
        {
            var query = this.TravelApiContext.Destinations.AsQueryable();
            if (city != null)
            {
                query = query.Where(x => x.City == city);
            }
            if (country != null)
            {
                query = query.Where(x => x.Country == country);
            }
            return query.ToList();
        }
        public IEnumerable<Destination> GetAllDestinations()
        {
            return FindAll()
            .OrderBy(x => x.City);
        }

        public IEnumerable<Destination> GetCountries()
        {
            return (from c in this.TravelApiContext.Destinations
                    select new Destination { DestinationId = c.DestinationId, Country = c.Country, City = c.City }).Distinct().ToList();

            // return (from d in ratings
            //         join dr in TravelApiContext.Destinations on d.DestinationId equals dr.DestinationId
            //         select new Destination { DestinationId = d.DestinationId, Country = dr.Country, City = dr.City }
            //              ).ToList();

            // return (from countries in FindAll()
            // select new { Country = countries.}
            // )
        }

        // public IQueryable<Destination> GetDestinations(string city, string country)
        // {
        //     var destinations = this.TravelApiContext.Destinations.AsQueryable();
        //     if (city != null)
        //     {
        //         destinations = destinations.Where(x => x.City == city);
        //     }
        //     if (country != null)
        //     {
        //         destinations = destinations.Where(x => x.Country == country);
        //     }
        //     return destinations;
        // }

        public Destination GetDestinationById(int id)
        {
            return FindByCondition(destination => destination.DestinationId == id).FirstOrDefault();
        }

        public IEnumerable<Destination> GetDestinationsByCityName(string city)
        {
            return FindByCondition(destination => destination.City.Equals(city)).ToList();
        }

        public IEnumerable<Destination> GetDestinationsByCountryName(string country)
        {
            return FindByCondition(destination => destination.Country.Equals(country)).ToList();
        }

        // public IEnumerable<Destination> GetDestinationsByCityAndCountry(string city, string country)
        // {
        //     return FindByCondition(destination => destination.Country.Equals(country) && destination.Country.Equals(city)).ToList();
        // }

        public IEnumerable<Destination> GetDestinationsByReviewCountDescending()
        {
            var mostReviewedDestination = TravelApiContext.Reviews
                    .GroupBy(review => review.DestinationId)
                    .Select(group => new { DestinationId = group.Key, Count = group.Count() })
                    .OrderByDescending(x => x.Count);

            return (from mrd in TravelApiContext.Destinations
                    join m in mostReviewedDestination
                    on mrd.DestinationId equals m.DestinationId
                    orderby m.Count descending
                    select new Destination { DestinationId = m.DestinationId, Country = mrd.Country, City = mrd.City }).ToList();
        }

        public IEnumerable<Destination> GetDestinationsAverageRatingDescending()
        {
            var ratings = TravelApiContext.Reviews
                  .GroupBy(review => review.DestinationId)
                  .Select(group => new { DestinationId = group.Key, Average = (TravelApiContext.Reviews.Where(x => x.DestinationId == group.Key).Average(x => x.Rating)) })
                  .OrderByDescending(x => x.Average);

            return (from d in ratings
                    join dr in TravelApiContext.Destinations on d.DestinationId equals dr.DestinationId
                    select new Destination { DestinationId = d.DestinationId, Country = dr.Country, City = dr.City }
                         ).ToList();
        }
    }
}