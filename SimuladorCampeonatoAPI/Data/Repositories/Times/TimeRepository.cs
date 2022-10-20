using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.Times
{
    public class TimeRepository : ITimeRepository
    {
        private readonly DataContext _context;

        public TimeRepository(DataContext context)
        {
            _context = context;
        }

        public Task<int> InsertAsync(Time time)
        {
            _context.AddAsync(time);
            return _context.SaveChangesAsync();
        }
    }
}