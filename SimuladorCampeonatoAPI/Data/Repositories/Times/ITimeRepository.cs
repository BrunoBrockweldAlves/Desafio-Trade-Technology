using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.Times
{
    public interface ITimeRepository
    {
        Task<int> InsertAsync(Time time);
    }
}