using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeCiBlog.Model
{
    public class Lookups
    {
        public IList<Category> Categories { get; set; }
        public IList<Link> Links { get; set; }
        public IList<User> Users { get; set; }
        public IList<string> Tags { get; set; }
    }
}
