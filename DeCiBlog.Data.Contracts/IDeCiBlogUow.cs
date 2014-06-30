using DeCiBlog.Model;

namespace DeCiBlog.Data.Contracts
{
    /// <summary>
    /// Interface for the DeCi Blog "Unit of Work"
    /// </summary>
    public interface IDeCiBlogUow
    {
        // Save pending changes to the data store.
        bool Commit();
        // Repositories
        IBlogEntryRepository BlogEntries { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IUserRepository Users { get; }
        IRepository<Link> Links { get; }

    }
}
