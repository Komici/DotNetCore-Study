using Microsoft.AspNetCore.Mvc;

namespace WebApiVersionDemo.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string GetStudents()
        {
            return "张三,李四";
        }
    }
}
