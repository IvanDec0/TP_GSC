using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess.Interfaces;
using TP_Back.DataAccess.Repository;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repositories
{
    public class UserRepository<T>: GenericRepository<User>, IUserRepository<T>
         where T : User

    {
        protected ThingsContext context;
        internal DbSet<T> dbSet;
        public UserRepository(ThingsContext context) : base(context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
            virtual public T? GetOneString(string name)
        {
            return dbSet.FirstOrDefault(x => x.UserName == name);
        }

        virtual public T FirstOrDefault(string name)
        {
            return (T)GetAll().FirstOrDefault(GetOneString(name)!);
        }
    
    }
}
