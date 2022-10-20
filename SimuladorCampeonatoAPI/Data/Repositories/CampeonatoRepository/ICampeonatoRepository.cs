using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.CampeonatoRepository
{
    public interface ICampeonatoRepository
    {
        Task<int> InsertAsync(Campeonato campeonato);
    }
}