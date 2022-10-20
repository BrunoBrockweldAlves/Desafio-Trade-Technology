using SimuladorCampeonatoAPI.Data.Repositories.CampeonatoRepository;
using SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos;
using SimuladorCampeonatoAPI.Data.Repositories.Times;
using SimuladorCampeonatoAPI.Services;

namespace SimuladorCampeonatoAPI.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ITimeRepository, TimeRepository>();
            services.AddSingleton<ICampeonatoRepository, CampeonatoRepository>();
            services.AddSingleton<ITimeCampeonatoRepository, TimeCampeonatoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationService, ApplicationService>();

            return services;
        }
    }
}