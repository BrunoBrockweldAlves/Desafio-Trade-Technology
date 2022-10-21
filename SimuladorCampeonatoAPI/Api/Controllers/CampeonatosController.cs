using MeuCampeonatoAPI.Application.Models;
using MeuCampeonatoAPI.Application.Services;
using MeuCampeonatoAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonatoAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeuCampeonatoController : ControllerBase
    {
        private readonly IApplicationService _appService;

        public MeuCampeonatoController(IApplicationService appService)
        {
            _appService = appService;
        }

        [HttpGet("resultado/{campeonatoId}")]
        public async Task<ResultadoCampeonatoViewModel> GetResultadoCampeonato([FromRoute] Guid campeonatoId)
        {
            return await _appService.GetResultadoCampeonatoByCampeonatoId(campeonatoId);
        }
        
        [HttpPost("campeonato")]
        public async Task<string> CriarCampeonato([FromBody] Campeonato campeonato)
        {
            return await _appService.CriarCampeonato(campeonato);
        }
        
        [HttpPost("time")]
        public async Task<string> CriarTime([FromBody] Time time)
        {
            return await _appService.CriarTime(time);
        }

        [HttpPost("executar/{campeonatoId}")]
        public async Task<string> ExecutarCampeonato([FromRoute] Guid campeonatoId)
        {
            var timeCampeao = await _appService.RealizarCampeonatoById(campeonatoId);

            return @$"Campeonato finalizado!
                      Time ganhador: {timeCampeao.Time.Nome}";
        }

        [HttpPost("associar/{timeId}/{campeonatoId}")]
        public async Task<string> AssociarTimeCampeonato([FromRoute] Guid campeonatoId, Guid timeId)
        {
            return await _appService.AssociarTimeCampeonato(campeonatoId, timeId);
        }
    }
}