using EasyPermissionManagement.Core.Extensions;
using EasyPermissionManagement.PostgreSql.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace EasyPermissionManagement.Web
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration Object
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration">
        /// Configuration Object
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940</summary>
        /// <param name="services">
        /// Specifies the contract for a collection of service descriptors.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEasyPermission();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
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

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// Defines a class that provides the mechanisms to configure an application's request pipeline.
        /// </param>
        /// <param name="env">
        /// Provides information about the web hosting environment an application is running in.
        /// </param>
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
