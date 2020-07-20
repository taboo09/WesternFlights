using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Flights.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Repositories
{
    public class AppRepository<TContext> : IAppRepository<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        public AppRepository(TContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.AddRange(entities);
        }

        public async Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return await _context.Set<T>().SingleOrDefaultAsync(condition);
        }

        public async Task<List<T>> FindEntities<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return await _context.Set<T>().Where(condition).ToListAsync();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void AttachEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
        }

        public async Task SaveAll() => await _context.SaveChangesAsync();
    }
}