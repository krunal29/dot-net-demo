using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DotNetDemo.Business.Interfaces.Repositories;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity
    {
        protected readonly DotNetDemoEntities Context;

        protected BaseRepository(DotNetDemoEntities context)
        {
            Context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual T Insert(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> InsertRange(IEnumerable<T> entities)
        {
            return Context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void DeleteBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var enumerable = Context.Set<T>().Where(predicate);
            Context.Set<T>().RemoveRange(enumerable);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) Context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            Dispose(false);
        }
    }
}
