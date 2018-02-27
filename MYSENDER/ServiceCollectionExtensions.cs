using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MYSENDER.Common.IRepositories;
using MYSENDER.Repositories;

namespace MYSENDER
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IHistoriqueRepository, HistoriqueRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
