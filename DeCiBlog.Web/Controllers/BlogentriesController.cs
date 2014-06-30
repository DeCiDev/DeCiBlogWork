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
    public class BlogentriesController : ApiControllerBase
    {

        public BlogentriesController(IDeCiBlogUow uow)
        {
            Uow = uow;
        }

        // GET /api/blogentries
        public IEnumerable<BlogEntry> Get(bool includeComments = false)
        {
            IQueryable<BlogEntry> results = includeComments
                ? Uow.BlogEntries.GetBlogEntriesIncludingComments()
                : Uow.BlogEntries.GetAll();

            var blogEntries = results
                .OrderByDescending(be => be.CreationDate)
                .Take(25)
                .ToList();
            return blogEntries;
        }

        // Create a new BlogEntry
        // POST /api/blogentries
        public HttpResponseMessage Post([FromBody] BlogEntry newEntry)
        {
            if (newEntry.CreationDate == default(DateTime))
            {
                newEntry.CreationDate = DateTime.UtcNow;
            }

            Uow.BlogEntries.Add(newEntry);
            if (Uow.Commit())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newEntry);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // GET /api/blogentries/5
        public BlogEntry Get(int id)
        {
            var entry = Uow.BlogEntries.GetById(id);
            if (entry != null)
            {
                return entry;
            }
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Update an existing blogentry
        // PUT /api/blogentries/
        public HttpResponseMessage Put(BlogEntry entry)
        {
            Uow.BlogEntries.Update(entry);
            if (Uow.Commit())
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE /api/blogentries/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.BlogEntries.Delete(id);
            if (Uow.Commit())
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
