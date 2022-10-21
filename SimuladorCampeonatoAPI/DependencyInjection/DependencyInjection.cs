using MeuCampeonatoAPI.Application.Services;
using MeuCampeonatoAPI.Domain.Repositories.CampeonatoRepository;
using MeuCampeonatoAPI.Domain.Repositories.TimeCampeonatos;
using MeuCampeonatoAPI.Domain.Repositories.Times;

namespace MeuCampeonatoAPI.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
            services.AddScoped<ITimeCampeonatoRepository, TimeCampeonatoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();

            return services;
        }
    }
}