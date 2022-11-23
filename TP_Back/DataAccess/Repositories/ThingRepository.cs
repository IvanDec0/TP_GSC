using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess;
using TP_Back.DataAccess.Interface;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repository
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(ThingsContext context) : base(context)
        {
        }
    }
}
