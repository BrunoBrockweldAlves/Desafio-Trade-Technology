using Microsoft.AspNetCore.Mvc;
using SimuladorCampeonato.Domain.Entities;

namespace SimuladorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimuladorCampeonatoController : ControllerBase
    {
        private readonly DataContext _context;

        public SimuladorCampeonatoController(DataContext context)
        {
            _context = context;
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
        //public async Task<ActionResult<List<Time>>> AddHero(Time hero)
        //{
        //    _context.Times.Add(hero);
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