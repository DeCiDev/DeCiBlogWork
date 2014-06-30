using System.Linq;
using DeCiBlog.Model;

namespace DeCiBlog.Data.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> GetCategoriesRecursive();
    }
}
