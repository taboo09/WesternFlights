using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flights.Domain.Core
{
    public interface IAppRepository<TContext> where TContext : class
    {
        void Add<T>(T entity) where T: class;
        void AddRange<T>(IEnumerable<T> entities) where T: class;
        void Remove<T>(T entity) where T: class;
        IQueryable<T> GetAll<T>() where T: class;
        Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class;
        Task<List<T>> FindEntities<T>(Expression<Func<T, bool>> condition) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        void AttachEntity<T>(T entity) where T : class;
        Task SaveAll();  
    }
}