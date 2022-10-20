using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Repositories.TimeCampeonatos
{
    public interface ITimeCampeonatoRepository
    {
        Task<int> InsertAsync(TimeCampeonato timeCampeonato);
        Task<int> UpdateAsync(TimeCampeonato timeCampeonato);
        Task<TimeCampeonato?> GetByIdAsync(Guid timeCampeonatoId);
        Task<IEnumerable<TimeCampeonato>> GetByCampeonatoIdAsync(Guid campeonatoId);
        public bool IsCampeonatoCheio(Guid campeonatoId);
    }
}