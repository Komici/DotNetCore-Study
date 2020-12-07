using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    [Table("bnt_posts")]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
