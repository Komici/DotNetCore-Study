using Microsoft.AspNetCore.Mvc;

namespace WebApiVersionDemo.Controllers.V1._1
{
    [ApiVersion("1.1")]
    [ApiController]
    //[Route("api/v{version:ApiVersion}/students")]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string GetStudents()
        {
            return "v1.1 张三,李四";
        }
    }
}
