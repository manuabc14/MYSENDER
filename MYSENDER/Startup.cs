using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MYSENDER.DatabaseModels;
using System;
using System.Linq;

namespace MYSENDER
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    /// COMMANDE A EXECUTER POUR RAFRAICHIER LE MODEL DE BASE DE DONNEE SI ON AJOUTE UNE TABLE OU SI ON LA SUPPRIME
    /// 
    /// Tools –> NuGet Package Manager –> Package Manager Console
    /// 
    //PM> Scaffold-DbContext "Server=TRSB1209002\SQLEXPRESS2014;Database=MYSENDER;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir MYSENDERContext
    /// 
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ///TO CALL DASHBOARD HANGFIRE
    /// https://app_hostname/hangfire
    /// 
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // and a lot more Services
            const string connection = @"Server=TRSB1209002\SQLEXPRESS2014;Database=MYSENDER;Trusted_Connection=True;";
            services.AddEntityFramework().AddDbContext<MySenderContext>(options => options.UseSqlServer(connection));
            // Add framework services.
            services.AddMvc();

            // hanfire sql
            services.AddHangfire(config => config.UseSqlServerStorage(Configuration.GetConnectionString("HangFireConnectionString")));

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.CookieHttpOnly = true;
                options.CookieName = ".MySender.Session";
            });
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
            });

            var _dbContext = new MySenderContext();
            var test = _dbContext.Emetteur.FirstOrDefault(id => id.Id == 1).Id;
        //    RecurringJob.AddOrUpdate(() => SmsModeServices.Instance.SendSmsForCurrentPlanning(),Cron.Minutely);
        }
    }
}
