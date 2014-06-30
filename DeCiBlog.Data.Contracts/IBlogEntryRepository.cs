using System.Linq;
using DeCiBlog.Model;

namespace DeCiBlog.Data.Contracts
{
    public interface IBlogEntryRepository : IRepository<BlogEntry>
    {
        IQueryable<BlogEntry> GetBlogEntriesIncludingComments();

        BlogEntry GetBlogEntryIncludingCommentsById(int id);
        IQueryable<BlogEntry> GetBlogEntriesByTag(string tag);
        
        IQueryable<BlogEntry> GetBlogEntriesByCategoryId(int id);

        IQueryable<BlogEntry> GetBlogEntriesByCrationYear(int year);

        IQueryable<BlogEntry> GetBlogEntriesByCrationMonth(int month);

        bool AddBlogEntry(BlogEntry newEntry);

        bool DeleteBlogEntry(BlogEntry entry);
    }
}