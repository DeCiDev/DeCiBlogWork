using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DeCiBlog.Data
{
    public class BlogMigrationConfiguration : DbMigrationsConfiguration<DeCiBlogDbContext>
    {
        public BlogMigrationConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeCiBlogDbContext context)
        {
            base.Seed(context);

#if DEBUG
            if (!context.BlogEntries.Any())
            {
                CreateSampleData(context);
            }
#endif
        }

        private void CreateSampleData(DeCiBlogDbContext context)
        {
            context.BlogEntries.AddRange(SampleData.SampleEntries.BlogEntries);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                Debug.WriteLine(sb.ToString());
            }
        }
    }
}