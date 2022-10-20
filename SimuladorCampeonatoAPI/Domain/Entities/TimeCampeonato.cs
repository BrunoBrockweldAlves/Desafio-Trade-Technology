using System.ComponentModel;

namespace MeuCampeonatoAPI.Domain.Entities
{
    [Index(nameof(TimeId), nameof(CampeonatoId), IsUnique = true)]
    public class TimeCampeonato
    {
        public TimeCampeonato(Guid timeId, Guid campeonatoId)
        {
            Id = Guid.NewGuid();
            TimeId = timeId;
            CampeonatoId = campeonatoId;
            TimeEliminado = false;
            PontuacaoTotal = 0;
        }

        public Guid Id { get; private set; }
        public Guid TimeId { get; private set; }
        public Guid CampeonatoId { get; private set; }


        #region Score
        [DefaultValue(false)]
        public bool TimeEliminado { get; private set; }

        [DefaultValue(0)]
        public short PontuacaoTotal { get; private set; }
        #endregion

        #region Methods
        public void EliminarTime() => TimeEliminado = true;

        public void AdicionarResultadoJogo(short golsMarcados, short golsSofridos)
        {
            PontuacaoTotal += (short)(golsMarcados - golsSofridos);
        }
        #endregion
    }
}