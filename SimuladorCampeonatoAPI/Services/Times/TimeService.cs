using SimuladorCampeonato.Domain.Entities;
using SimuladorCampeonatoAPI.Data.Repositories.Times;

namespace SimuladorCampeonatoAPI.Services.Times
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;

        public Task<bool> CriarTime(Time time)
        {
            throw new NotImplementedException();
        }
    }
}