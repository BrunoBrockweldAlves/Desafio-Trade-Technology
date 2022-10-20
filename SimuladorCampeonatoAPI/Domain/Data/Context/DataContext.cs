using MeuCampeonatoAPI.Domain.Entities;

namespace MeuCampeonatoAPI.Domain.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<TimeCampeonato> TimeCampeonatos { get; set; }
    }
}