using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApiVersionDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //�汾���Ʒ�ʽ(1-ͨ��·�ɿ��ơ�2-ͨ��url�������ơ�3-ͨ��header��������)
            //����(1-û��ָ���汾��ʱ��ʽ2��3��������,��δ���2-ͬһ��controllerͬʱ֧�ֶ���汾��3-����һ���汾)
            //���WebApi�汾���Ʒ���
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                //options.ApiVersionReader = new Microsoft.AspNetCore.Mvc.Versioning.HeaderApiVersionReader("api-version");
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
