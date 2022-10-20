using MeuCampeonatoAPI.Domain.Entities;
using MeuCampeonatoAPI.Domain.Repositories.CampeonatoRepository;
using MeuCampeonatoAPI.Domain.Repositories.TimeCampeonatos;
using MeuCampeonatoAPI.Domain.Repositories.Times;

namespace MeuCampeonatoAPI.Application.Services
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
                $"Time {time.Nome} criado com sucesso!" :
                $"Houve um erro ao criar o time {time.Nome}.";
        }
        #endregion

        #region Campeonato
        public async Task<string> CriarCampeonato(Campeonato campeonato)
        {
            var criadoComSucesso = await _campeonatoRepository.InsertAsync(campeonato);

            return criadoComSucesso == 1 ?
                $"Campeonato {campeonato.Nome} criado com sucesso!" :
                $"Houve um erro ao criar o campeonato {campeonato.Nome}.";
        }

        public void RealizarCampeonato(Guid campeonatoId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TimeCampeonato
        public async Task<string> AssociarTimeCampeonato(Guid timeId, Guid campeonatoId)
        {
            if (_timeCampeonatoRepository.IsCampeonatoCheio(campeonatoId))
            {
                return "Impossível associar time: Campeonato já está cheio!";
            }

            var timeCampeonato = new TimeCampeonato(timeId, campeonatoId);

            var associadoComSucesso = await _timeCampeonatoRepository.InsertAsync(timeCampeonato);

            return associadoComSucesso == 1 ?
               "Time associado com sucesso!" :
               "Houve um erro ao associar o time ao campeonato.";
        }

        public async Task<string> EliminarTime(Guid timeCampeonatoId)
        {
            var timeCampeonato = await _timeCampeonatoRepository.GetById(timeCampeonatoId);

            if (timeCampeonato == null)
                return "Time não encontrado!";

            timeCampeonato.EliminarTime();

            var eliminadoComSucesso = await _timeCampeonatoRepository.UpdateAsync(timeCampeonato);

            return eliminadoComSucesso == 1 ?
               "Time associado com sucesso!" :
               "Houve um erro ao associar o time ao campeonato.";
        }
        #endregion

        #region ExecutarCampeonato
        public void ExecutarCampeonato()
        {

        }
        #endregion
    }
}