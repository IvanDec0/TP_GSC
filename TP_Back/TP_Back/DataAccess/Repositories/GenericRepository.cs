using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using TP_Back.DataAccess;
using TP_Back.DataAccess.Interface;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : GenericEntity
    {

        protected ThingsContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(ThingsContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        virtual public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        virtual public List<T> GetAll(Func<T, bool> condition)
        {
            return dbSet.Where(condition).ToList();
        }

        virtual public T? GetOne(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        

        virtual public T add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        virtual public T update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }

        virtual public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = GetOne(id);
            if (entity is not null)
                Delete(entity);
        }


        // Async Methods
        public async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T>? GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = dbSet;
            if (include != null)
            {
                query = include(query);
            }

            Task<T?> task = query.AsNoTracking().FirstOrDefaultAsync(expression);
            return await task;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
        }

    }
}
