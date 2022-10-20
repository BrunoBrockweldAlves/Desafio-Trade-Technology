using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.Times
{
    public interface ITimeRepository
    {
        Task<int> Insert(Time time);
        Task<bool> ChecarNomeExistente(string nome);
    }
}