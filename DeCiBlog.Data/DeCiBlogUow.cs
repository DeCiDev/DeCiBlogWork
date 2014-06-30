using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Data.Helpers;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="BlogEntry"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class DeCiBlogUow : IDeCiBlogUow, IDisposable
    {
        public DeCiBlogUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }
        public bool Commit()
        {
            try
            {
                DbContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var sb = new StringBuilder();
                foreach (var item in dbEx.EntityValidationErrors)
                {
                    sb.Append(item + " errors: ");
                    foreach (var i in item.ValidationErrors)
                    {
                        sb.Append(i.PropertyName + " : " + i.ErrorMessage);
                    }
                    sb.Append(Environment.NewLine);
                }
                // TODO logging
                return false;
            }
            catch (Exception ex)
            {
                // TODO logging 
                return false;
            }
        }

        public IBlogEntryRepository BlogEntries { get { return GetRepo<IBlogEntryRepository>(); } }
        public ICategoryRepository Categories { get { return GetRepo<ICategoryRepository>(); } }
        public ICommentRepository Comments { get { return GetRepo<ICommentRepository>(); } }
        public IUserRepository Users { get { return GetRepo<IUserRepository>(); } }
        public IRepository<Link> Links { get { return GetStandardRepo<Link>(); } }
        protected void CreateDbContext()
        {
            DbContext = new DeCiBlogDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private DeCiBlogDbContext DbContext { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}

