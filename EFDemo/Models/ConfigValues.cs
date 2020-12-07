using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    [Table("bnt_configs")]
    public class ConfigValues
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
