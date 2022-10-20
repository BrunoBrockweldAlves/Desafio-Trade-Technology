using MeuCampeonatoAPI.Domain.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonatoAPI.Api.Controllers
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