using System;
using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Model
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public virtual int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual BlogEntry BlogEntry { get; set; }

        public virtual int BlogEntryId { get; set; }
    }
}