using SimuladorCampeonato.Domain.Entities;
using SimuladorCampeonatoAPI.Data.Repositories.CampeonatoRepository;
using SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos;
using SimuladorCampeonatoAPI.Data.Repositories.Times;

namespace SimuladorCampeonatoAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ITimeRepository _timeRepository;
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly ITimeCampeonatoRepository _timeCampeonatoRepository;

        public ApplicationService(ITimeRepository timeRepository, ICampeonatoRepository campeonatoRepository, ITimeCampeonatoRepository timeCampeonatoRepository)
        {
            _timeRepository = timeRepository;
            _campeonatoRepository = campeonatoRepository;
            _timeCampeonatoRepository = timeCampeonatoRepository;
        }

        #region Time
        public async Task<string> CriarTime(Time time)
        {
            var criadoComSucesso = await _timeRepository.InsertAsync(time);

            return criadoComSucesso == 1 ?
                "Time criado com sucesso!" :
                "Houve um erro ao criar o time.";
        }
        #endregion

        #region Campeonato
        public void RealizarCampeonato(Guid campeonatoId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TimeCampeonato
        #endregion
    }
}