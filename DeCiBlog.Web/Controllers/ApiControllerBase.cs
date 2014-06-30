using System.Web.Http;
using DeCiBlog.Data.Contracts;

namespace DeCiBlog.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IDeCiBlogUow Uow { get; set; }
    }
}
