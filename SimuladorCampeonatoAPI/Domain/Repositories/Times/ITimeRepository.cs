using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Repositories.Times
{
    public interface ITimeRepository
    {
        Task<int> InsertAsync(Time time);
        Task<IEnumerable<Time>> GetAll();
    }
}