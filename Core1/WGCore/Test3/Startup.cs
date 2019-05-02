using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EntityExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test3
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(typeof(MyExceptionFilter));
            services.AddMvc(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var filter=serviceProvider.GetService<MyExceptionFilter>();
                options.Filters.Add(filter);
            });
            services.AddMemoryCache();

            #region 第一种注入
            Assembly asmBLL = Assembly.Load(new AssemblyName("BLL"));
            var serviceBLLTypes = asmBLL.GetTypes().Where(t => typeof(IServiceSupportExten).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract);
            foreach (var serviceType in serviceBLLTypes)
            {
                foreach (var interType in serviceType.GetInterfaces())
                {
                    services.AddSingleton(interType, serviceType);
                }
            }

            Assembly asmDAL = Assembly.Load(new AssemblyName("DAL"));
            var serviceDALTypes = asmDAL.GetTypes().Where(t => typeof(IServiceSupportExten).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract);
            foreach (var serviceType in serviceDALTypes)
            {
                foreach (var interType in serviceType.GetInterfaces())
                {
                    services.AddSingleton(interType, serviceType);
                }
            }
            #endregion

            #region 第二种注入
            //services.AddSingleton(typeof(IUserInfoService), typeof(UserInfoService));
            //services.AddSingleton(typeof(IUserInfoBLL), typeof(UserInfoBLL));
            #endregion
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
