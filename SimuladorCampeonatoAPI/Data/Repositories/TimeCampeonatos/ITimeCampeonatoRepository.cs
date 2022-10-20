namespace SimuladorCampeonatoAPI.Data.Repositories.TimeCampeonatos
{
    public interface ITimeCampeonatoRepository
    {
        public bool IsCampeonatoCheio(Guid campeonatoId);
    }
}