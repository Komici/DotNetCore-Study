using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTDemo.ApiAuthorizePolicy
{
    /// <summary>
    /// 权限授权Handler
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// 验证方案提供对象
        /// </summary>
        public IAuthenticationSchemeProvider Schemes { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="schemes"></param>
        public PermissionHandler(IAuthenticationSchemeProvider schemes)
        {
            Schemes = schemes;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.Claims.Any())
            {
                if (context.Resource is Endpoint endpoint)
                {
                    var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                    var theController = actionDescriptor.RouteValues["controller"];
                    var theAction = actionDescriptor.RouteValues["action"];
                    //判断过期时间
                    if (DateTime.Parse(context.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration).Value) >= DateTime.Now)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
            };

            return Task.CompletedTask;
        }

        //private void SetFail(AuthorizationHandlerContext context, PermissionRequirement requirement)
        //{
        //    var result = new ApiResult();
        //    result.ReturnCode = "401";
        //    result.Msg = "Api授权失败";

        //    var authorizationFilterContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext);
        //    authorizationFilterContext.Result = new JsonResult(result);
        //    context.Succeed(requirement);
        //}

        //private void SetDue(AuthorizationHandlerContext context, PermissionRequirement requirement)
        //{
        //    var result = new ApiResult();
        //    result.ReturnCode = "403";
        //    result.Msg = "服务已到期";

        //    var authorizationFilterContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext);
        //    authorizationFilterContext.Result = new JsonResult(result);
        //    context.Succeed(requirement);
        //}
    }
}
