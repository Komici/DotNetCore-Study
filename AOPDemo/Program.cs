using Castle.DynamicProxy;
using System;

namespace AOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ProxyGenerator proxyGenerator = new ProxyGenerator();
            object[] param = { "Hello DoSome2" };
            //SomeInterface proxyClass = proxyGenerator.CreateClassProxy<ImpClass1>(new SomeInterceptor());
            SomeInterface proxyClass = (SomeInterface)proxyGenerator.CreateClassProxy(typeof(ImpClass2),param,new SomeInterceptor()); 
            proxyClass.DoSome();
        }
    }
}
