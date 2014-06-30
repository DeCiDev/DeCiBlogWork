using System;
using System.Data.Entity;
using System.Linq;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    public class BlogEntryRepository : EfRepository<BlogEntry>, IBlogEntryRepository
    {
        public BlogEntryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<BlogEntry> GetBlogEntries()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<BlogEntry> GetBlogEntriesIncludingComments()
        {
            return DbSet.Include(be => be.Comments);
        }

        public BlogEntry GetBlogEntryIncludingCommentsById(int id)
        {
            return DbSet.Include(be => be.Comments).FirstOrDefault(be => be.Id == id);
        }

        public IQueryable<BlogEntry> GetBlogEntriesByTag(string tag)
        {
            return DbSet.Where(be => be.Tags.Contains(tag));
        }

        public IQueryable<BlogEntry> GetBlogEntriesByCategoryId(int id)
        {
            return DbSet.Where(be => be.Categories.Any(c => c.Id == id));
        }

        public IQueryable<BlogEntry> GetBlogEntriesByCrationYear(int year)
        {
            return DbSet.Where(be => be.CreationDate.Year == year);
        }

        public IQueryable<BlogEntry> GetBlogEntriesByCrationMonth(int month)
        {
            return DbSet.Where(be => be.CreationDate.Month == month);
        }

        public BlogEntry GetBlogEntry(int id)
        {
            return GetById(id);
        }

        public bool AddBlogEntry(BlogEntry newEntry)
        {
            try
            {
                Add(newEntry);
                return true;
            }
            catch (Exception ex)
            {
                // TODO logging 
                return false;
            }
        }

        public bool DeleteBlogEntry(BlogEntry entry)
        {
            try
            {
                Delete(entry);
                return true;
            }
            catch (Exception ex)
            {
                // TODO logging 
                return false;
            }

        }

    }
}
