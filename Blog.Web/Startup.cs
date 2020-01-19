using System.Linq;
using System.Reflection;
using Autofac;
using Blog.Infrastructure.EntityFrameworkCore;
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddControllersWithViews()
                .AddControllersAsServices();
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
        /// ��������
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // �������õĳ���
            var entryAssembly = Assembly.GetEntryAssembly()
                ?.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(x => x.FullName.Contains("Blog.Application")
                                 || x.FullName.Contains("Blog.Core")
                                 || x.FullName.Contains("Blog.Infrastructure"))
                .ToArray();

            // ��Ӳִ�ע��
            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // ��ӷ���ע��
            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            // ��Controller��ʹ������ע��
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();
        }
    }
}
