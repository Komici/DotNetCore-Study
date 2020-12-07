using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XunitTestDemo;

namespace XUnitTestProject1
{
    public class WeatherForecastTests
    {
        private readonly IArticleService _articleService;
        public WeatherForecastTests(ITestOutputHelper outputHelper, IArticleService articleService)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            Client = server.CreateClient();

            //添加授权
            //string token = "";
            //Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Output = outputHelper;
            _articleService = articleService;
        }

        public HttpClient Client { get; }

        public ITestOutputHelper Output { get; }

        [Fact]
        public async Task GetById_ShouldBe_Ok()
        {
            // Arrange
            var id = 1;

            // Act
            var count = _articleService.GetCount();
            var response = await Client.GetAsync($"/WeatherForecast");

            // Output
            var responseText = await response.Content.ReadAsStringAsync();
            Output.WriteLine(responseText);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestRandom1000000()
        {
            // Arrange
            var id = 1;
            var count = 10000;
            // Act
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            for (var i=0;i<=count;i++)
            {
                Output.WriteLine(i.ToString());
            }
            stopWatch.Stop();

            // Output
            Output.WriteLine("占用时间:"+ stopWatch.ElapsedMilliseconds.ToString());

            // Assert
            var hasOverTime = stopWatch.ElapsedMilliseconds/1000 > 10;
            Assert.True(hasOverTime);
        }
    }
}
