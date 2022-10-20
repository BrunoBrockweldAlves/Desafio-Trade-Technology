using Microsoft.EntityFrameworkCore;
using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonato.Domain.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Time> TimesCampeonatos { get; set; }
    }
}