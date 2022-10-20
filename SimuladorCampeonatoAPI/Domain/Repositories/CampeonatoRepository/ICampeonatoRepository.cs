using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Repositories.CampeonatoRepository
{
    public interface ICampeonatoRepository
    {
        Task<int> InsertAsync(Campeonato campeonato);
        Task<IEnumerable<Campeonato>> GetAll();
    }
}