using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSRedisDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            RedisHelper.Subscribe(
("chan1", msg => Console.WriteLine(msg.Body)),
("chan2", msg => Console.WriteLine(msg.Body)));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //设置缓存
            RedisHelper.Set("testa:001", "aaa");
            var testa = RedisHelper.Get("testa:001");

            //模式订阅（通配符）
            RedisHelper.PSubscribe(new[] { "test*", "*test001", "test*002" }, msg => {
                Console.WriteLine($"PSUB   {msg.MessageId}:{msg.Body}    {msg.Pattern}: chan:{msg.Channel}");
            });
            RedisHelper.Publish("chan1", "123123123");

            //将key中储存的数字加上指定的增量值
            var result = await RedisHelper.IncrByAsync("userid", 1);


            return Ok("");
        }
    }
}
