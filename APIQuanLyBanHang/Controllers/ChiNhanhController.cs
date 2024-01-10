using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIQuanLyBanHang.Model;


namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiNhanhController : ControllerBase
    {
        private readonly QlbdaTtsContext _context;

        public ChiNhanhController(QlbdaTtsContext context)
        {
            _context = context;
        }

        // GET: api/ChiNhanh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiNhanh>>> GetChiNhanhs()
        {
          if (_context.ChiNhanhs == null)
          {
              return NotFound();
          }
            return await _context.ChiNhanhs.ToListAsync();
        }

        // GET: api/ChiNhanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiNhanh>> GetChiNhanh(string id)
        {
          if (_context.ChiNhanhs == null)
          {
              return NotFound();
          }
            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);

            if (chiNhanh == null)
            {
                return NotFound();
            }

            return chiNhanh;
        }

        // PUT: api/ChiNhanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiNhanh(string id, ChiNhanh chiNhanh)
        {
            if (id != chiNhanh.IdchiNhanh)
            {
                return BadRequest();
            }

            _context.Entry(chiNhanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiNhanhExists(id))
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

        // POST: api/ChiNhanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiNhanh>> PostChiNhanh(ChiNhanh chiNhanh)
        {
          if (_context.ChiNhanhs == null)
          {
              return Problem("Entity set 'QlbdaTtsContext.ChiNhanhs'  is null.");
          }
            _context.ChiNhanhs.Add(chiNhanh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiNhanhExists(chiNhanh.IdchiNhanh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiNhanh", new { id = chiNhanh.IdchiNhanh }, chiNhanh);
        }

        // DELETE: api/ChiNhanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiNhanh(string id)
        {
            if (_context.ChiNhanhs == null)
            {
                return NotFound();
            }
            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);
            if (chiNhanh == null)
            {
                return NotFound();
            }

            _context.ChiNhanhs.Remove(chiNhanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiNhanhExists(string id)
        {
            return (_context.ChiNhanhs?.Any(e => e.IdchiNhanh == id)).GetValueOrDefault();
        }
    }
}
