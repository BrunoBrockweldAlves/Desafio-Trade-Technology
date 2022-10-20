using Microsoft.AspNetCore.Mvc;
using SimuladorCampeonatoAPI.Services.Time;

namespace SimuladorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimesController(ITimeService timeService)
        {
            _timeService = timeService;
        }
      
    }
}