using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductTracker.Interface.Common
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        void Add(T entity);
        void Delete(object id);
        void Update(T entity);
        void Save();
    }
}
