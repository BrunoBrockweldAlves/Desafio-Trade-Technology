namespace MeuCampeonatoAPI.Application.Models
{
    public class ResultadoCampeonatoViewModel
    {
        public string Nome { get; set; }
        public string TimeGanhadorNome { get; set; }
        public List<TimeCampeonatoResultadoViewModel> ResultadoCampeonatoList { get; set; }
    }
}
