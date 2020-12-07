using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly DotnetCoreDemoDbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var configs = _context.ConfigValues;
            //var list = configs.ToList<ConfigValues>();

            //using (var context = new DotnetCoreDemoDbContext())
            //{
            //    var blog = new ConfigValues { Id="CompanyConfig",Value="test company"};
            //    context.ConfigValues.Add(blog);
            //    context.SaveChanges();
            //}

            //using (var context = new DotnetCoreDemoDbContext())
            //{
            //    var blog = new Blog
            //    {
            //        Id = Guid.NewGuid(),
            //        Url = "http://blogs.msdn.com/dotnet",
            //        Posts = new List<Post>
            //        {
            //            new Post { Id = Guid.NewGuid(), Title = "Intro to C#" },
            //            new Post { Id = Guid.NewGuid(),  Title = "Intro to VB.NET" },
            //            new Post { Id = Guid.NewGuid(),  Title = "Intro to F#" }
            //        }
            //    };

            //    context.Blogs.Add(blog);
            //    context.SaveChanges();
            //}

            using (var context = new DotnetCoreDemoDbContext())
            {
                var blog = context.Blogs.Include(b => b.Posts).First();
                var post = blog.Posts.First();

                blog.Posts.Remove(post);
                context.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
