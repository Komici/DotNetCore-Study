using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutofacDemo.Models;
using AutofacDemo.Services;
using Autofac;
using Autofac.Core;

namespace AutofacDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<NameService> _logger;

        //private readonly IValuesService _valuesService;


        //public HomeController(ILogger<HomeController> logger, IValuesService valuesService)
        //{
        //    _logger = logger;
        //    _valuesService = valuesService;
        //}

        public HomeController(ILogger<NameService> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            //var list = _valuesService.FindAll();
            //var item = _valuesService.Find(3);
            IValuesService vs1 = Env.Container.Resolve<IValuesService>();
            var list1 = vs1.FindAll();

            //var builder = new ContainerBuilder();
            //builder.RegisterType<ValuesService>().Named<IValuesService>(typeof(ValuesService).Name);
            //builder.RegisterType<NameService>().Named<IValuesService>(typeof(NameService).Name);
            //IContainer container = builder.Build();
            //IValuesService vs = container.ResolveNamed<IValuesService>(typeof(ValuesService).Name);
            //var list2 = vs.FindAll();

            //IValuesService vs = Env.Container.ResolveNamed<IValuesService>(typeof(ValuesService).Name);
            IValuesService vsKey = Env.Container.ResolveKeyed<IValuesService>("Name");
            var list2 = vsKey.FindAll();


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
