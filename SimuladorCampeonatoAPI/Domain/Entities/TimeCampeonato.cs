﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
            FoiEliminado = false;
            PontuacaoTotal = 0;
            DataInscricao = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public Guid CampeonatoId { get; private set; }

        public Guid TimeId { get; private set; }
        public virtual Time Time {get ; set;}


        #region Score
        [DefaultValue(false)]
        public bool FoiEliminado { get; private set; }

        [DefaultValue(0)]
        public short PontuacaoTotal { get; private set; }

        [DefaultValue(0)]
        public short PenaltisTotais { get; private set; }

        [Required]
        public DateTime DataInscricao { get; private set; }
        #endregion

        #region Methods
        public void EliminarTime() => FoiEliminado = true;

        public void AdicionarSaldoGolsJogo(short golsMarcados, short golsSofridos)
        {
            PontuacaoTotal += (short)(golsMarcados - golsSofridos);
        }

        public void AdicionarSaldoPenaltisJogo(short golsMarcados, short golsSofridos)
        {
            PenaltisTotais += (short)(golsMarcados - golsSofridos);
        }
        #endregion
    }
}