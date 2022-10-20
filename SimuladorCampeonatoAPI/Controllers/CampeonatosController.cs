using Microsoft.AspNetCore.Mvc;

namespace SimuladorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private readonly DataContext _context;

        public CampeonatosController(DataContext context)
        {
            _context = context;
        }

       
    }
}