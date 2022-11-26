using TP_Back.DataAccess.Interface;
using TP_Back.DataAccess.Interfaces;
using TP_Back.Entities;

namespace TP_Back.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepo { get; }
        public IPersonRepository PeopleRepo { get; }
        public IThingRepository ThingsRepo { get; }
        public IUserRepository<User> UsersRepo { get; }
        public ILoanRepository LoansRepo { get; }

        public int SaveChanges();

        Task SaveAsync();
    }
}
