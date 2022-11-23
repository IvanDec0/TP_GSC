using TP_Back.DataAccess.Interfaces;
using TP_Back.DataAccess.Repository;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ThingsContext context) : base(context)
        {
        }
    }
}
