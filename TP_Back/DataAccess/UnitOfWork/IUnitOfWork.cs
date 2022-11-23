using TP_Back.DataAccess.Interface;
using TP_Back.DataAccess.Interfaces;

namespace TP_Back.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepo { get; }
        public IPersonRepository PeopleRepo { get; }
        public IThingRepository ThingsRepo { get; }
        public IUserRepository UsersRepo { get; }

        public int SaveChanges();

        Task SaveAsync();
    }
}
