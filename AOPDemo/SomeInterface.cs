using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOPDemo
{
    public interface SomeInterface
    {
        void DoSome();
    }


    public class ImpClass1 : SomeInterface
    {
        public virtual void DoSome()
        {
            Console.WriteLine("hello DoSome");
        }
    }

    public class ImpClass2 : SomeInterface
    {
        private string _s;

        public ImpClass2(string s)
        {
            this._s = s;
        }

        public virtual void DoSome()
        {
            Console.WriteLine(_s);
        }
    }

    public class SomeInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("方法执行前");
            try
            {
                invocation.Proceed();
            }
            catch
            {
                //...                
            }
            Console.WriteLine("方法执行后");
        }
    }
}
