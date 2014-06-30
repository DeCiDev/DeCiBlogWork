using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public virtual List<BlogEntry> BlogEntries { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
    }
}