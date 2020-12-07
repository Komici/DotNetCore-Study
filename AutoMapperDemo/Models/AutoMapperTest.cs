using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models
{
    public class mapperSet : Profile
    {
        public mapperSet()
        {
            CreateMap<Person, PersonDto>();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string GetName { get; set; }
        public string tmpEmail { get; set; }
        public int Age { get; set; }
    }

    public class PersonDto
    {
        public int Idfff { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DtoAge { get; set; }
    }
}
