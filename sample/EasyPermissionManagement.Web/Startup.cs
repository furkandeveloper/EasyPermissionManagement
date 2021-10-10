using EasyPermissionManagement.Core.Extensions;
using EasyPermissionManagement.PostgreSql.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace EasyPermissionManagement.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEasyPermission();
            services.UseEasyPermissionNpgsql(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("EasyPermissionManagement", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Easy Permission Management",
                    Version = "1.0.0",
                    Description = "This repo, provides query profiler for EF Core.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "furkan.dvlp@gmail.com",
                        Url = new Uri("https://github.com/furkandeveloper/EasyProfiler")
                    }
                });
                var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

                if (File.Exists((filePath)))
                {
                    options.IncludeXmlComments(filePath);
                }
                options.DescribeAllParametersInCamelCase();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseEasyPermission();

            app.ApplyEasyPermission();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.EnableDeepLinking();
                options.ShowExtensions();
                options.DisplayRequestDuration();
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.RoutePrefix = "api-docs";
                options.SwaggerEndpoint("/swagger/EasyPermissionManagement/swagger.json", "EasyPermissionManagementSwagger");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
