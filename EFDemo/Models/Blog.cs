using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    [Table("bnt_blogs")]
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
