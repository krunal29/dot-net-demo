using DotNetDemo.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetDemo.Business.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Get(int id);

        T Get(Guid id);

        T Insert(T entity);

        IEnumerable<T> InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteAll(IEnumerable<T> entities);

        void Update(T entity);

        void Save();

        void DeleteBy(Expression<Func<T, bool>> predicate);
    }
}
