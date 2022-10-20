using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Application.Services
{
    public interface IApplicationService
    {
        #region Time
        Task<string> CriarTime(Time time);
        #endregion

        #region Campeonato
        public void RealizarCampeonato(Guid campeonatoId);
        #endregion

        #region TimeCampeonato

        #endregion

    }
}
