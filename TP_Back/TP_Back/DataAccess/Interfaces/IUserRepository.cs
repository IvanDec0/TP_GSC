using TP_Back.DataAccess.Interface;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Interfaces
{
    public interface IUserRepository<T> : IGenericRepository<User>
        where T : User
    {
        public T? GetOneString(string name);

        public T FirstOrDefault(string name);
    }
}
