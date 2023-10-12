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
            return await _context.Bikers.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Biker> GetBikerById(int id) {
            var biker = _context.Bikers.Find(id);
            return Ok(biker);
        }

        [HttpPost]
        public ActionResult<Biker> PostBiker(List<Biker> biker) {
            biker.ForEach(n => _context.Bikers.Add(n));
            _context.SaveChanges();
            return Ok(biker);
        }

        [HttpPut("{id}")]
        public ActionResult<Biker> EditBiker(Biker biker) {
            _context.Bikers.Update(biker);
            _context.SaveChanges();
            return Ok(biker);
        }

        [HttpDelete("{id}")]
        public ActionResult<Biker> DeleteBiker(int id) {
            var biker = _context.Bikers.Find(id);
            _context.Bikers.Remove(biker);
            _context.SaveChanges();
            return Ok(biker);
        }
    }
}