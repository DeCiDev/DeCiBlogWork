using System.Data.Entity;
using System.Linq;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Category> GetCategoriesRecursive()
        {
            return DbSet.Include(c => c.Children);
        }
    }
}
