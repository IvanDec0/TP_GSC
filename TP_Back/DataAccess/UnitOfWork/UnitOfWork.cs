using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess.Interface;
using TP_Back.DataAccess.Repository;

namespace TP_Back.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ThingsContext _thingsContext;
        public ICategoryRepository CategoryRepo { get; private set; }
        public IPersonRepository PeopleRepo { get; private set; }
        public IThingRepository ThingsRepo { get; private set; }

        public UnitOfWork(ThingsContext thingsContext)
        {
            this._thingsContext = thingsContext;

            CategoryRepo = new CategoryRepository(thingsContext);
            PeopleRepo = new PersonRepository(thingsContext);
            ThingsRepo = new ThingRepository(thingsContext);
        }

        public int SaveChanges() => this._thingsContext.SaveChanges();

        public async Task SaveAsync()
        {
            await _thingsContext.SaveChangesAsync();
        }

    }
}
