using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuickstartIdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public ResourceOwnerPasswordValidator()
        {

        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var claimList = new List<Claim>()
                 {

                     new Claim(ClaimTypes.Name, $"alice"),
                     new Claim(JwtClaimTypes.Role.ToString(),UserRoleEnum.Manage.ToString())
                 };
            //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
            if (context.UserName == "alice" && context.Password == "password")
            {
                context.Result = new GrantValidationResult(
                 subject: "alice",
                 authenticationMethod: "custom",
                 claims: claimList.ToArray());

                //context.Result = new GrantValidationResult(
                // subject: "alice",
                // authenticationMethod: "custom");
            }
            //else
            //{

            //    //验证失败
            //    context.Result = new GrantValidationResult(
            //        TokenRequestErrors.InvalidGrant, 
            //        "invalid custom credential",
            //        );
            //}
            return Task.FromResult(0);
        }

    }
}
