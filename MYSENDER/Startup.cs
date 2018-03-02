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
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Localization;

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
        public Startup(IConfiguration configuration)
        {
			Configuration = configuration as IConfigurationRoot;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MYSENDERContext>(options =>options.UseSqlServer(Configuration["ConnectionStrings:DatabaseConnection"]));
            services.AddMvc();
            // hanfire sql
            services.AddHangfire(config => config.UseSqlServerStorage(Configuration["ConnectionStrings:DatabaseConnection"]));
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".MySender.Session";
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

            var di = new DirectoryInfo(Path.Combine(env.WebRootPath, @"lib\cldr-data\main"));
            var supportedCultures = di.GetDirectories().Where(x => x.Name != "root").Select(x => new CultureInfo(x.Name)).ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures.FirstOrDefault(x => x.Name == "fr")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // var _dbContext = new MySenderContext();
            // var test = _dbContext.Emetteur.FirstOrDefault(id => id.Id == 1).Id;
            //    RecurringJob.AddOrUpdate(() => SmsModeServices.Instance.SendSmsForCurrentPlanning(),Cron.Minutely);
        }
    }
}
