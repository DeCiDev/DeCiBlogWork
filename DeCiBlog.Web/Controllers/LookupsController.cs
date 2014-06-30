using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Web.Controllers
{
    public class LookupsController : ApiControllerBase
    {
        public LookupsController(IDeCiBlogUow uow)
        {
            Uow = uow;
        }

        // GET: api/lookups/tags
        [ActionName("tags")]
        public IEnumerable<string> GetTags()
        {
            return Uow.BlogEntries.GetAll().OrderBy(be => be.CreationDate).Select(be => be.Tags);
        }

        // GET: api/lookups/links
        [ActionName("links")]
        public IEnumerable<Link> GetLinks()
        {
            return Uow.Links.GetAll().OrderBy(t => t.Name); 
        }

        // GET: api/lookups/categories
        [ActionName("categories")]
        public IEnumerable<Category> GetCategories()
        {
            return Uow.Categories.GetCategoriesRecursive();
        }


        // Lookups: aggregates the many little lookup lists in one payload
        // to reduce roundtrips when the client launches.
        // GET: api/lookups
        [ActionName("all")]
        public Lookups GetLookups()
        {
            var lookups = new Lookups
            {
                Tags = GetTags().ToList(),
                Links = GetLinks().ToList(),
                Categories = GetCategories().ToList(),

            };

            return lookups;
        }

    }
}
