using Microsoft.AspNetCore.Mvc;
using SimuladorCampeonatoAPI.Services;

namespace SimuladorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly IApplicationService _timeService;

        public TimesController(IApplicationService timeService)
        {
            _timeService = timeService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Time>>> Get()
        //{
        //    return Ok(await _context.Times.ToListAsync());
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Time>> Get(int id)
        //{
        //    var hero = await _context.Times.FindAsync(id);
        //    if (hero == null)
        //        return BadRequest("Hero not found.");
        //    return Ok(hero);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Time hero)
        //{
        //    _timeService
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Times.ToListAsync());
        //}

        //[HttpPut]
        //public async Task<ActionResult<List<Time>>> UpdateHero(Time request)
        //{
        //    var dbHero = await _context.Times.FindAsync(request.Id);
        //    if (dbHero == null)
        //        return BadRequest("Hero not found.");

        //    dbHero.Name = request.Name;
        //    dbHero.FirstName = request.FirstName;
        //    dbHero.LastName = request.LastName;
        //    dbHero.Place = request.Place;

        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Times.ToListAsync());
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Time>>> Delete(int id)
        //{
        //    var dbHero = await _context.Times.FindAsync(id);
        //    if (dbHero == null)
        //        return BadRequest("Hero not found.");

        //    _context.Times.Remove(dbHero);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Times.ToListAsync());
        //}
    }
}