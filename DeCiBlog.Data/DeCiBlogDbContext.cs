using System.Data.Entity;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    public class DeCiBlogDbContext : DbContext
    {
        public DeCiBlogDbContext() : base("Name=DeCiBlog")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DeCiBlogDbContext, BlogMigrationConfiguration>());
        }

        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Link> BlogRoll { get; set; }
    }
}
