using TP_Back.DataAccess;
using TP_Back.DataAccess.Interface;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ThingsContext context) : base(context)
        {
        }
    }
}
