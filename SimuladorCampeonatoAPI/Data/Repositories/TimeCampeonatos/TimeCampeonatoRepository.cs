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

        public Task<int> InsertAsync(TimeCampeonato timeCampeonato)
        {
            _context.AddAsync(timeCampeonato);
            return _context.SaveChangesAsync();
        }

        public bool IsCampeonatoCheio(Guid campeonatoId)
        {
            return _context.TimeCampeonatos.Where(x => x.CampeonatoId == campeonatoId).Count() >= 8;
        }
    }
}