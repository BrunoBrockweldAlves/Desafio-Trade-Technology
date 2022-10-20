using MeuCampeonatoAPI.Application.Models;
using MeuCampeonatoAPI.Application.Utils;
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

        public async Task<ResultadoCampeonatoViewModel> GetResultadoCampeonatoByCampeonatoId(Guid campeonatoId)
        {
            var campeonato = await _campeonatoRepository.GetById(campeonatoId);

            if (campeonato == null)
            {
                throw new Exception("Campeonato não encontrado!");
            }

            var timeCampeonatos = await _timeCampeonatoRepository.GetByCampeonatoIdAsync(campeonatoId);

            var resultadoCampeonato = new ResultadoCampeonatoViewModel
            {
                Nome = campeonato.Nome,
                ResultadoCampeonatoList = timeCampeonatos.OrderBy(x => x.PontuacaoTotal)
                                                         .ThenBy(x => x.DataInscricao)
                                                         .Select((x, index) => new TimeCampeonatoResultadoViewModel
                                                         {
                                                             Colocacao = (short)index,
                                                             Nome = x.Time.Nome,
                                                             Pontuacao = x.PontuacaoTotal
                                                         }).ToList()
            };

            return resultadoCampeonato;
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
            var timeCampeonato = await _timeCampeonatoRepository.GetByIdAsync(timeCampeonatoId);

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
        public async Task RealizarCampeonatoById(Guid campeonatoId)
        {
            //TODO Implementar
            var timeCampeonatos = await _timeCampeonatoRepository.GetByCampeonatoIdAsync(campeonatoId);

        }

        public TimeCampeonato DefinirTimeGanhador(ref TimeCampeonato timeUm, ref TimeCampeonato timeDois)
        {
            var pyHelper = new PythonHelper();
            var resultado = pyHelper.GerarResultadosJogo();

            var golsTimeUm = resultado[0];
            var golsTimeDois = resultado[1];

            timeUm.AdicionarSaldoGolsJogo(golsTimeUm, golsTimeDois);
            timeDois.AdicionarSaldoGolsJogo(golsTimeDois, golsTimeUm);

            if (golsTimeUm > golsTimeDois)
                return timeUm;

            else if (golsTimeDois > golsTimeUm)
                return timeDois;

            return Desempatar(timeUm, timeDois);
        }

        #region Desempate
        public TimeCampeonato Desempatar(TimeCampeonato timeUm, TimeCampeonato timeDois) => DesempatarPorPenaltis(timeUm, timeDois);

        public TimeCampeonato DesempatarPorPenaltis(TimeCampeonato timeUm, TimeCampeonato timeDois)
        {
            var timeUmSeInscreveuAntes = timeUm.DataInscricao.CompareTo(timeDois.DataInscricao);

            if (timeUmSeInscreveuAntes > 0)
                return timeUm;

            else if (timeUmSeInscreveuAntes < 0)
                return timeDois;

            return DesempatarPorDataInscricao(timeUm, timeDois);
        }

        public TimeCampeonato DesempatarPorDataInscricao(TimeCampeonato timeUm, TimeCampeonato timeDois)
        {
            var timeUmSeInscreveuAntes = timeUm.DataInscricao.CompareTo(timeDois.DataInscricao);

            return timeUmSeInscreveuAntes > 0 ?
                timeUm :
                timeDois;
        }
        #endregion Desempate
        #endregion TimeCampeonato
    }
}