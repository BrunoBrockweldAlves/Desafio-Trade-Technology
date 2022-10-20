using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Services.Times
{
    public interface ITimeService
    {
        public Task<bool> CriarTime(Time time);
    }
}
