using System.Linq;
using System.Reflection;
using Autofac;
using Blog.Infrastructure.EntityFrameworkCore;
using Blog.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.Web
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

            #region EntityFrameworkCore

            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            #endregion

            #region AutoMapper

            services.AddAutoMapperSetup();

            #endregion

            #region Autofac

            services.AddControllersWithViews()
                .AddControllersAsServices();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var entryAssembly = Assembly.GetEntryAssembly()
                ?.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(x => x.FullName.Contains(".Application")
                                 || x.FullName.Contains(".Core")
                                 || x.FullName.Contains(".EntityFrameworkCore"))
                .ToArray();

            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("Blog.Core"))
                .Where(x => x.Name.EndsWith("Manager"))
                .AsSelf();

            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // 在Controller中使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();
        }
    }
}
