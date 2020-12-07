using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTDemo.ApiAuthorizePolicy
{
    public static class JwtBearerTokenExtension
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, string issuer, string audience, string secret,bool isHttps = false,string defaultScheme = "ApiBearer")
        {
            //添加jwt身份验证
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            JwtBearer.DefaultScheme = defaultScheme;
            services.AddAuthentication(options => {
                options.DefaultScheme = defaultScheme;
                options.DefaultAuthenticateScheme = defaultScheme;
                options.DefaultChallengeScheme = nameof(ApiResponseHandler);
            })
                .AddJwtBearer(defaultScheme, options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = audience,//Audience
                        ValidIssuer = issuer,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),//拿到SecurityKey
                        ClockSkew = TimeSpan.Zero
                    };
                    options.RequireHttpsMetadata = isHttps;
                    options.Audience = audience;
                    options.ClaimsIssuer = issuer;
                })
                .AddScheme<JwtBearerOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o =>
                {
                });
        }

        public static void AddJwtBearerPolicy(this IServiceCollection services, string issuer, string audience, string secret, TimeSpan expirationTimeSpan, bool isHttps = false, string defaultScheme = "ApiBearer", string policyName = "Api")
        {
            var keyByteArray = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = issuer,//发行人
                ValidAudience = audience,//订阅人
                IssuerSigningKey = signingKey,
                ClockSkew = TimeSpan.Zero,
                //RequireExpirationTime = true,
            };
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            //如果第三个参数，是ClaimTypes.Role，上面集合的每个元素的Name为角色名称，如果ClaimTypes.Name，即上面集合的每个元素的Name为用户名
            var permissionRequirement = new PermissionRequirement(
                ClaimTypes.Role,
                issuer,
                audience,
                signingCredentials,
                expiration: expirationTimeSpan);

            services.AddSingleton(permissionRequirement);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(policyName, policy => policy.Requirements.Add(permissionRequirement));
            });

            services.AddTransient<IAuthorizationHandler, PermissionHandler>();
        }
    }
}
