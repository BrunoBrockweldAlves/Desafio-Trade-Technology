using MeuCampeonatoAPI.Domain.Data.Context;
using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Repositories.CampeonatoRepository
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

        public async Task<Campeonato?> GetById(Guid campeonatoId)
        {
            return await _context.Campeonatos.FirstOrDefaultAsync(x => x.Id == campeonatoId);
        }
    }
}