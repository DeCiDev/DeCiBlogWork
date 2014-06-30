using System.Data.Entity;
using System.Linq;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    public class CommentRepository : EfRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Comment> GetCommentByEntryId(int id)
        {
            return DbSet.Where(c => c.BlogEntryId == id).OrderBy(c => c.Created);
        }
    }
}
