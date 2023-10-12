using biker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace biker.Controller {
    [ApiController]
    [Route("/api/[controller]")]
    public class BikerController : ControllerBase {
        private readonly APIDbContext _context;

        public BikerController(APIDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biker>>> GetBikers()
        { 
            var bikers = await _context.Bikers.ToListAsync();
            foreach (var biker in bikers)
            {
                biker.National = _context.Nationals.Find(biker.NationalId);
            }
            return Ok(bikers);
        }

        [HttpGet("{id}")]
        public ActionResult<Biker> GetBikerById(int id) {
            var biker = _context.Bikers.Find(id);
            if (biker == null) {
                return NotFound();
            }
            biker.National = _context.Nationals.Find(biker.NationalId);
            return Ok(biker);
        }

        [HttpPost]
        public ActionResult<Biker> PostBiker([FromBody] List<Biker> bikers)
        {
            foreach (var biker in bikers)
            {
                biker.National = _context.Nationals.Find(biker.NationalId);
            }

            bikers.ForEach(n => _context.Bikers.Add(n));
            _context.SaveChanges();
            return Ok(bikers);
        }

        // [HttpPut("{id}")]
        // public async ActionResult<Biker> EditBiker(Biker biker, int id) {
        //     var bikerToEdit = _context.Bikers.Find(id);
        //     if (bikerToEdit == null) {
        //         return NotFound();
        //     }
        //      _context.Bikers.Update(biker);
        //     await _context.SaveChangesAsync();
        //     return Ok(biker);
        // }


        [HttpDelete("{id}")]
        public ActionResult<Biker> DeleteBiker(int id) {
            var biker = _context.Bikers.Find(id);
            if (biker == null) {
                return NotFound();
            }
            _context.Bikers.Remove(biker);
            _context.SaveChanges();
            return Ok(biker);
        }
    }
}