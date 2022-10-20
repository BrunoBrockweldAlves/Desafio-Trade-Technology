﻿using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos
{
    public class TimeCampeonatoRepository : ITimeCampeonatoRepository
    {
        private readonly DataContext _context;

        public TimeCampeonatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> InsertAsync(TimeCampeonato timeCampeonato)
        {
            await _context.AddAsync(timeCampeonato);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TimeCampeonato timeCampeonato)
        {
            _context.Update(timeCampeonato);
            return await _context.SaveChangesAsync();
        }

        public async Task<TimeCampeonato?> GetById(Guid timeCampeonatoId)
        {
            return await _context.TimeCampeonatos.FirstOrDefaultAsync(x => x.Id == timeCampeonatoId);
        }

        public bool IsCampeonatoCheio(Guid campeonatoId)
        {
            return _context.TimeCampeonatos.Where(x => x.CampeonatoId == campeonatoId).Count() >= 8;
        }

        public async Task<IEnumerable<TimeCampeonato>> GetAllByCampeonatoId(Guid campeonatoId)
        {
            return await _context.TimeCampeonatos.Where(x => x.CampeonatoId == campeonatoId).ToListAsync();
        }
    }
}