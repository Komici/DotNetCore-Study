using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCDemo.Services
{
    public class TestSayService:TestSay.TestSayBase
    {
        public override Task<TestReply> SayTest(TestRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TestReply
            {
                Message = $"Hello { context.Method} " + request.Name

            });
        }
    }
}
