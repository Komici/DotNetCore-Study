using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersionDemo.Controllers.V2._0
{
    [ApiVersion("2.0",Deprecated =true)]
    [ApiVersion("3.0")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/students")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string GetStudents()
        {
            return "v2.0 张三,李四";
        }

        [Route("scores")]
        [HttpGet]
        public string GetStudentScore([FromQuery]EnumDemoQueryModel enumDemoQueryModel)
        {
            if (!Enum.IsDefined(typeof(Sex), enumDemoQueryModel.Sex))
            {
                return "性能不对";
            }
            return "80,90,100";
        }

        [Route("AddScore")]
        [HttpGet]
        public string GetStudentScore([FromBody]string studentId)
        {
            return "80,90,100";
        }
    }

    public class EnumDemoQueryModel
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Man = 0,
        Woman = 1
    }
}
