﻿using MeuCampeonatoAPI.Domain.Data.Context;
using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Repositories.Times
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

        public async Task<IEnumerable<Time>> GetAll()
        {
            return await _context.Times.ToListAsync();
        }
    }
}