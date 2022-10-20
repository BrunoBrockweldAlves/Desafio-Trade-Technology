using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonato.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<TimeCampeonato> TimeCampeonatoS { get; set; }
    }
}