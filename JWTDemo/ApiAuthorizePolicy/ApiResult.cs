using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.ApiAuthorizePolicy
{
    public class ApiResult
    {
        public ApiResult()
        {
        }
        public string ReturnCode { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public DateTime ReturnTime { get; set; }

        public void SetData(object data)
        {
            Data = data;
        }
    }
}
