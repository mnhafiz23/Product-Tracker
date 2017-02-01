using Microsoft.EntityFrameworkCore;
using ProductTracker.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductTracker.DataAccess.Common
{
    public class GenericRepository<T> : IGenericRepository<T>
          where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbSet.AsEnumerable<T>();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }


        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
