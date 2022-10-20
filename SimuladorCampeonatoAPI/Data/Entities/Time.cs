using System.ComponentModel.DataAnnotations;


namespace SimuladorCampeonato.Domain.Entities
{
    [Index(nameof(Nome), IsUnique=true)]
    public class Time
    {
        public Time(string nome, DateTime dataInscricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInscricao = dataInscricao;
        }

        public Guid Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; private set; }

        [Required]
        public DateTime DataInscricao { get; private set; }
    }
}