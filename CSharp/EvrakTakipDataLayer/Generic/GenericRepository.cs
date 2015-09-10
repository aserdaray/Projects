using EvrakTakipDataLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvrakTakipDataLayer.Generic
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable
        where T: class , new()
    {
        internal EvrakTakipEntities _entities = new EvrakTakipEntities();


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_entities != null)
                {
                    _entities.Dispose();
                    _entities = null;
                }
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            var query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

     
    }
}
