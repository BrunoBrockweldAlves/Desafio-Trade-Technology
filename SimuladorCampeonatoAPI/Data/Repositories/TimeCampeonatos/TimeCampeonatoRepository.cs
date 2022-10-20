namespace SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos
{
    public class TimeCampeonatoRepository : ITimeCampeonatoRepository
    {
        private readonly DataContext _context;

        public TimeCampeonatoRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsCampeonatoCheio(Guid campeonatoId)
        {
            return _context.TimeCampeonatos.Where(x => x.CampeonatoId == campeonatoId).Count() >= 8;
        }
    }
}