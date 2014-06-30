using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Web.Controllers
{
    public class CommentsController : ApiControllerBase
    {
        public CommentsController(IDeCiBlogUow uow)
        {
            Uow = uow;
        }

        public IEnumerable<Comment> Get(int entryId)
        {
            return Uow.Comments.GetCommentByEntryId(entryId);
        }

        public HttpResponseMessage Post(int entryId, [FromBody] Comment newComment)
        {
            if (newComment.Created == default(DateTime))
            {
                newComment.Created = DateTime.UtcNow;
            }

            newComment.BlogEntryId = entryId;

            Uow.Comments.Add(newComment);

            if (Uow.Commit())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newComment);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }

}
