﻿using System.ComponentModel.DataAnnotations;


namespace MeuCampeonatoAPI.Domain.Entities
{
    [Index(nameof(Nome), IsUnique = true)]
    public class Time
    {
        public Time(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; private set; }
    }
}