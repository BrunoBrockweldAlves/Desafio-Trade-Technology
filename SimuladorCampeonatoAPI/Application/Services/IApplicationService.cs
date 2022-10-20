using MeuCampeonatoAPI.Application.Models;
using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Application.Services
{
    public interface IApplicationService
    {
        #region Time
        Task<string> CriarTime(Time time);
        #endregion

        #region Campeonato
        Task<string> CriarCampeonato(Campeonato campeonato);
        Task<ResultadoCampeonatoViewModel> GetResultadoCampeonatoByCampeonatoId(Guid campeonatoId);
        Task RealizarCampeonatoById(Guid campeonatoId);
        #endregion

        #region TimeCampeonato
        Task<string> AssociarTimeCampeonato(Guid timeId, Guid campeonatoId);
        Task<string> EliminarTime(Guid timeCampeonatoId);
        #endregion

    }
}
