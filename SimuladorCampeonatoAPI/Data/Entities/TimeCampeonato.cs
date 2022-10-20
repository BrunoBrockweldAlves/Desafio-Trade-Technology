namespace SimuladorCampeonato.Domain.Entities
{
    [Index(nameof(TimeId), nameof(CampeonatoId), IsUnique = true)]
    public class TimeCampeonato
    {
        public Guid Id { get; set; }
        public Guid TimeId { get; set; }
        public Guid CampeonatoId { get; set; }
    }
}