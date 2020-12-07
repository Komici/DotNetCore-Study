using Autofac;
using AutofacDemo.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //当接口只有一种实现，或接口有多种实现但只使用最后注册的那个，可以用As
            builder.RegisterType<NameService>()
                   .As<IValuesService>();

            //当接口有多种实现，而且至少需要使用其中的两种实现时用Named和Keyed
            //builder.RegisterType<ValuesService>().Named<IValuesService>(typeof(ValuesService).Name);
            //builder.RegisterType<NameService>().Named<IValuesService>(typeof(NameService).Name);

            //builder.RegisterType<ValuesService>().Keyed<IValuesService>("Value");
            //builder.RegisterType<NameService>().Keyed<IValuesService>("Name");

        }
    }
}
