using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos
{
    public interface ITimeCampeonatoRepository
    {
        Task<int> InsertAsync(TimeCampeonato timeCampeonato);
        Task<TimeCampeonato> GetById(Guid timeCampeonatoId);
        public bool IsCampeonatoCheio(Guid campeonatoId);
    }
}