using JWTDemo.ApiAuthorizePolicy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JWTDemo
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

            //���jwt�����֤
            JwtSettingOptions jwtSettingOptions = new JwtSettingOptions();
            Configuration.GetSection("JwtSetting").Bind(jwtSettingOptions);
            if (jwtSettingOptions == null)
                throw new ArgumentNullException("Audience", "Audience �ڵ�δ����");

            services.Configure<JwtSettingOptions>(Configuration.GetSection("JwtSetting"));

            services.AddJwtBearerAuthentication(jwtSettingOptions.Issuer, jwtSettingOptions.Audience, jwtSettingOptions.Secret);

            //����Զ�����Ȩ
            services.AddJwtBearerPolicy(jwtSettingOptions.Issuer, jwtSettingOptions.Audience, jwtSettingOptions.Secret, TimeSpan.FromDays(7));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();//������֤
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
