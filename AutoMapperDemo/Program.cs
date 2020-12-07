using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoMapperDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.DtoAge, opt => {
                    opt.MapFrom(src => src.Age);
                    opt.Condition(src => src.Age > 20);
                })
                .ForMember(dest => dest.Idfff, opt => {
                    opt.Ignore();
                });

                cfg.ClearPrefixes();
                cfg.RecognizePrefixes("tmp");
            });
            // only during development, validate your mappings; remove it before release
            //configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = configuration.CreateMapper();

            Person person = new Person()
            {
                Id = 1,
                GetName = "zz",
                Age = 18,
                tmpEmail = "1234567@qq.com"
            };
            var personDto = mapper.Map<PersonDto>(person);

            //var personDtoList = mapper.Map<List<PersonDto>>(new List<Person>() { person });

            PersonDto dto = new PersonDto();
            //_mapper.Map(person, dto);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
