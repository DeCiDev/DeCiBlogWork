using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Model
{
    public class Link
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string Description { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Url { get; set; }

        public virtual ICollection<BlogEntry> BlogEntries { get; set; }
    }
}
