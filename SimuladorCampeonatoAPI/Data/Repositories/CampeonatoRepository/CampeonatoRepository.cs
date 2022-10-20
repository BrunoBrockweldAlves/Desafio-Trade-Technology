using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.CampeonatoRepository
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly DataContext _context;

        public CampeonatoRepository(DataContext context)
        {
            _context = context;
        }

        public Task<int> InsertAsync(Campeonato campeonato)
        {
            _context.AddAsync(campeonato);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campeonato>> GetAll()
        {
            return await _context.Campeonatos.ToListAsync();
        }
    }
}