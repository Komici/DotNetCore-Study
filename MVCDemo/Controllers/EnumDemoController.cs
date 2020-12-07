using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class EnumDemoController : Controller
    {
        public IActionResult Add([FromQuery]EnumDemoQueryModel enumDemoQueryModel)
        {
            if (Enum.IsDefined(typeof(Sex), enumDemoQueryModel.Sex))
            {
                return Content("性能不对");
            }
            return Content("OK");
        }
    }

    public class EnumDemoQueryModel
    {
        public Sex Sex;
    }

    public enum Sex
    {
        Man = 0,
        Woman = 1
    }
}
