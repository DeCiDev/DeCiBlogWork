using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;

namespace DeCiBlog.Data
{
    class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserByName(string userName)
        {
            return DbSet.FirstOrDefault(u => u.Name.ToLower() == userName.ToLower());
        }
    }
}
