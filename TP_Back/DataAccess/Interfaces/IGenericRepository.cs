using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Interface
{
    public interface IGenericRepository<T>
        where T : GenericEntity
    {
        public T? GetOne(int id);

        public List<T> GetAll();

        public List<T> GetAll(Func<T, bool> condition);

        public T add(T entity);

        public T update(T entity);

        public void Delete(T entity);

        public void DeleteById(int id);


        // Async Methods
        Task InsertAsync(T entity);

        Task<T>? GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task DeleteAsync(int id);
    }
}
