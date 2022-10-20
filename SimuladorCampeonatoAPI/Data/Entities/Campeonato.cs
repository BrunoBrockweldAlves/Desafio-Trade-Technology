﻿using System.ComponentModel.DataAnnotations;

namespace SimuladorCampeonato.Domain.Entities
{
    [Index(nameof(Nome), IsUnique = true)]
    public class Campeonato
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}