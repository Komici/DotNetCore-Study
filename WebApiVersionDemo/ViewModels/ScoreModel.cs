using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersionDemo.ViewModels
{
    public class ScoreAddModel
    {

        public Guid StudentId { get; set; }

        public double ChineseScore { get; set; }

        public double MathScore { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
