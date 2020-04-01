using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TravelApi.Models;

namespace TravelApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TravelApiContext TravelApiContext { get; set; }

        public RepositoryBase(TravelApiContext travelApiContext)
        {
            this.TravelApiContext = travelApiContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.TravelApiContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.TravelApiContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.TravelApiContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.TravelApiContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.TravelApiContext.Set<T>().Remove(entity);
        }
    }
}