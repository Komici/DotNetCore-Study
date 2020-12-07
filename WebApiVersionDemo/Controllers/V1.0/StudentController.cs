using Microsoft.AspNetCore.Mvc;

namespace WebApiVersionDemo.Controllers.V1._0
{
    [ApiVersion("1.0")]
    [ApiController]
    //[Route("api/v{version:ApiVersion}/students")]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string GetStudents()
        {
            return "v1.0 张三,李四";
        }
    }
}
