using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().OpenMainsSwitch();

            Console.ReadKey();
        }

        public void OpenMainsSwitch()
        {

            //测试异步编程
            //Console.WriteLine("普通的同步{0}", GetCurrentThreadID());

            //Task task = CommandOpenMainsSwitch();



            //Console.WriteLine("同步方法第一句话{0}", GetCurrentThreadID());

            //Console.WriteLine("同步方法第二句话{0}", GetCurrentThreadID());

            //task.Wait();    //阻塞带有await的异步方法即阻塞异步方法第二句话，直到第二句话执行完再执行其他
            //////或者
            ////while (!task.IsCompleted) { Thread.Sleep(100); }

            //Console.WriteLine("同步方法第三句话{0}", GetCurrentThreadID());


            //上传文件示例
            //Console.WriteLine("开始上传文件", GetCurrentThreadID());
            //var uploadFileTask = UploadFile();
            //Console.WriteLine("上传文件中,先处理其他事情", GetCurrentThreadID());
            //Console.WriteLine("主线程执行完成", GetCurrentThreadID());
            //if (uploadFileTask.Result)
            //{
            //    Console.WriteLine("上传文件成功回调处理", GetCurrentThreadID());
            //}

            //测试await
            Task taskTestAwait =  TestAwait();
        }
        public async Task CommandOpenMainsSwitch()
        {
            Console.WriteLine("执行异步方法的的第一句话{0}", GetCurrentThreadID());
            await Task.Run(() =>
            {
                Console.WriteLine("执行异步方法的的第二句话", GetCurrentThreadID());
                Thread.Sleep(3000);
            });

            Console.WriteLine("执行异步方法的的第三句话{0}", GetCurrentThreadID());
            Thread.Sleep(6000);
            Console.WriteLine("执行异步方法的的第四句话{0}", GetCurrentThreadID());
        }
        public string GetCurrentThreadID()
        {
            return Thread.CurrentThread.ManagedThreadId.ToString("00");
        }

        public async Task<bool> UploadFile()
        {
            var success = false;
            await Task.Run(()=> {
                Thread.Sleep(5000);
                Console.WriteLine("上传文件成功", GetCurrentThreadID());
                success = true;
            });
            return success;
        }

        public async Task TestAwait()
        {
            TestAwaitJob1();

            await TestReturn();

            Console.WriteLine("TestAwait");
        }

        public async Task TestAwaitJob1()
        {
            Console.WriteLine("TestAwaitJob1开始了");
            //await Task.Run(() => {
            //    Thread.Sleep(5000);
            //    Console.WriteLine("TestAwaitJob1休息了5秒");
            //});
            await TestAwaitJob2();
            Console.WriteLine("TestAwaitJob1快完成了");
            Thread.Sleep(2000);
        }

        public async Task TestAwaitJob2()
        {
            Console.WriteLine("TestAwaitJob2开始了");
            await Task.Run(() => {
                Thread.Sleep(5000);
                Console.WriteLine("TestAwaitJob2休息了5秒");
            });
            Console.WriteLine("TestAwaitJob2快完成了");
            Thread.Sleep(2000);
        }

        public async Task TestReturn()
        {
            var a = 0;
            return;
            var b = 0;
        }
    }
}
