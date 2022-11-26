using TP_Back.DataAccess;
using TP_Back.DataAccess.Interface;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ThingsContext context) : base(context)
        {
        }
    }
}
