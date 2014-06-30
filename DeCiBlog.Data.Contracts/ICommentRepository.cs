using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeCiBlog.Model;

namespace DeCiBlog.Data.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetCommentByEntryId(int id);

    }
}
