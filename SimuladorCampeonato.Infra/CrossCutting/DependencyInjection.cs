using Microsoft.Extensions.DependencyInjection;
using SimuladorCampeonato.Domain.Data;
using SimuladorCampeonato.Domain.Repositories;
using SimuladorCampeonato.Infra.Repositories;

namespace SimuladorCampeonato.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            ConfigureContext(services);

            services.AddSingleton<ICampeonatoRepository, CampeonatoRepository>();
            services.AddSingleton<ITimeCampeonatoRepository, TimeCampeonatoRepository>();
            services.AddSingleton<ITimeRepository, TimeRepository>();

            return services;
        }

        private static IServiceCollection ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>();

            return services;
        }
    }
}