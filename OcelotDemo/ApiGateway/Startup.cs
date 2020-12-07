using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOcelot();
            string allowOriginStr = Configuration["Cors:AllowOrigins"];
            if (allowOriginStr == "*" || string.IsNullOrWhiteSpace(allowOriginStr))
            {
                //���ÿ���������������Դ��������ʹ��AllowAnyOrigin
                services.AddCors(options => options.AddPolicy("AllowOrigins", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            }
            else
            {
                string[] allowOriginArr = allowOriginStr.Split(",");
                //���ÿ���������ָ����Դ��            
                services.AddCors(options => options.AddPolicy("AllowOrigins", p => p.WithOrigins(allowOriginArr).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowOrigins");

            app.UseStaticFiles();
            //��������,ȫ�ֿ���
            app.UseOcelot().Wait();
        }
    }
}
