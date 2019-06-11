using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DotNetCoreTestDemo.Bll;
using DotNetCoreTestDemo.Dal;
using DotNetCoreTestDemo.IBll;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Mis.Controllers;
using DotNetCoreTestDemo.Mis.Filter;
using DotNetCoreTestDemo.Model;
using DotNetCoreTestDemo.Model.Models;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreTestDemo.Mis
{
    public class Startup
    {
        public static ILoggerRepository Repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Repository = LogManager.CreateRepository("NETCoreRepository");
            var fileInfo =
                new FileInfo("log4net.config");
          XmlConfigurator.Configure(Repository,fileInfo );
         
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            
            services.AddMvc(options=>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var builder = RegisterAutofac(services);
            return new AutofacServiceProvider(builder.Build());
        }

        /// <summary>
        /// 注册autofac
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private  ContainerBuilder RegisterAutofac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var service = Assembly.Load("DotNetCoreTestDemo.Bll");
            var iservice = Assembly.Load("DotNetCoreTestDemo.IBll");

            builder.RegisterAssemblyTypes(iservice, service).Where(i => i.Name.EndsWith("Service")).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var dal = Assembly.Load("DotNetCoreTestDemo.Dal");
            var idal = Assembly.Load("DotNetCoreTestDemo.IDal");
            builder.RegisterAssemblyTypes(idal, dal).Where(i => i.Name.EndsWith("Dal")).AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //注入ef对象
       
         var connectString=  Configuration["EFCoreSqlConnectString"];
            builder.Register(i =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreTestDemoDbContext>();
                optionsBuilder.UseSqlServer(connectString,
                    b => b
                        .MigrationsAssembly("DotNetCoreTestDemo.Model"));
                return optionsBuilder.Options;
            }).InstancePerLifetimeScope();
            builder.RegisterType<DotNetCoreTestDemoDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.Populate(services);
            builder.RegisterType<HomeController>().PropertiesAutowired();
            return builder;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
