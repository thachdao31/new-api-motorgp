using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using biker.Models;

namespace biker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PointsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Points>>> Gets()
        {
            var points = await _context.Points.ToListAsync();
            foreach ( var point in points ) {
                point.Biker = _context.Bikers.Find(point.BikerId);
                point.Races = _context.Races.Find(point.RacesId);
            }
            return Ok(points);
        }

        // GET: api//5
        [HttpGet("{id}")]
        public async Task<ActionResult<Points>> Get(int id)
        {
            var points  = await _context.Points.FindAsync(id);

            if (points == null)
            {
                return NotFound();
            }
            points.Biker = _context.Bikers.Find(points.BikerId);
            points.Races = _context.Races.Find(points.RacesId);

            return points;
        }

        // // PUT: api//5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id,  Points points)
        // {
        //     if (id != points.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(points).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!Exists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Points>> Post(Points points )
        {
            points.Biker = _context.Bikers.Find(points.BikerId);
            points.Races = _context.Races.Find(points.RacesId);
            _context.Add(points);
            await _context.SaveChangesAsync();

            return Ok(points);
        }

        // DELETE: api//5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var points = await _context.Points.FindAsync(id);
            if (points == null)
            {
                return NotFound();
            }

            _context.Points.Remove(points);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(int id)
        {
            return _context.Points.Any(e => e.Id == id);
        }
    }
}
