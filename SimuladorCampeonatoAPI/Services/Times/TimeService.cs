using SimuladorCampeonato.Domain.Entities;
using SimuladorCampeonatoAPI.Data.Repositories.CampeonatoRepository;
using SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos;
using SimuladorCampeonatoAPI.Data.Repositories.Times;

namespace SimuladorCampeonatoAPI.Services.Times
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly ITimeCampeonatoRepository _timeCampeonatoRepository;

        public TimeService(ITimeRepository timeRepository, ICampeonatoRepository campeonatoRepository, ITimeCampeonatoRepository timeCampeonatoRepository)
        {
            _timeRepository = timeRepository;
            _campeonatoRepository = campeonatoRepository;
            _timeCampeonatoRepository = timeCampeonatoRepository;
        }

        public async Task<int> CriarTime(Time time)
        {
            if (ValidarTime(time).Result)
            {
                throw new ArgumentException("Time já existe na base de dados");
            }

            var criadoComSucesso = await _timeRepository.Insert(time);
        }

        private async Task<bool> ValidarTime(Time time)
        {
            return await _timeRepository.ChecarNomeExistente(time.Nome);

        }
    }
}