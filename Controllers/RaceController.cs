using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using biker.Models;

namespace new_api_motorgp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly APIDbContext _context;

        public RaceController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Race
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Races>>> GetRaces()
        {
            return await _context.Races.ToListAsync();
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Races>> GetRace(int id)
        {
            var Race = await _context.Races.FindAsync(id);

            if (Race == null)
            {
                return NotFound();
            }

            return Race;
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, Races Race)
        {
            if (id != Race.Id)
            {
                return BadRequest();
            }

            _context.Entry(Race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Race
        [HttpPost]
        public async Task<ActionResult<Races>> PostRace(List<Races> Race)
        {
            Race.ForEach(n => _context.Races.Add(n));
            await _context.SaveChangesAsync();

            return Ok(Race);
        }

        // DELETE: api/Race/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var Race = await _context.Races.FindAsync(id);
            if (Race == null)
            {
                return NotFound();
            }

            _context.Races.Remove(Race);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.Id == id);
        }
    }
}
