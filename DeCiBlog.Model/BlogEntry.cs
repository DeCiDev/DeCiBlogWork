using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Model
{
    public class BlogEntry
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        public string Tags { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Link> Links { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual int? CreatorId { get; set; }
        public virtual User Creator { get; set; }
    }
}
