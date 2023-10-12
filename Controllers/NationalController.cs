using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using biker.Models;

namespace biker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalController : ControllerBase
    {
        private readonly APIDbContext _context;

        public NationalController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/national
        [HttpGet]
        public async Task<ActionResult<IEnumerable<National>>> GetNationals()
        {
            return await _context.Nationals.ToListAsync();
        }

        // GET: api/national/5
        [HttpGet("{id}")]
        public async Task<ActionResult<National>> GetNational(int id)
        {
            var national = await _context.Nationals.FindAsync(id);

            if (national == null)
            {
                return NotFound();
            }

            return national;
        }

        // PUT: api/national/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutNational(int id, National national)
        // {
        //     var nationalToEdit = _context.Nationals.Find(id);
        //     if (nationalToEdit == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Entry(national).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!NationalExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //     var nationalEdited = _context.Nationals.Find(id);
        //     return Ok(nationalEdited);
        // }

        // POST: api/national
        [HttpPost]
        public async Task<ActionResult<National>> PostNational(List<National> national)
        {
            national.ForEach(n => _context.Nationals.Add(n));
            await _context.SaveChangesAsync();

            return Ok(national);
        }

        // DELETE: api/national/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNational(int id)
        {
            var national = await _context.Nationals.FindAsync(id);
            if (national == null)
            {
                return NotFound();
            }

            _context.Nationals.Remove(national);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalExists(int id)
        {
            return _context.Nationals.Any(e => e.Id == id);
        }
    }
}
