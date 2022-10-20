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

        public Task<int> Insert(Time time)
        {
            _context.AddAsync(time);
            return _context.SaveChangesAsync();
        }

        public Task<bool> ChecarNomeExistente(string nome)
        {
            return _context.Times.AnyAsync(x => string.Equals(x.Nome,nome));
        }
    }
}