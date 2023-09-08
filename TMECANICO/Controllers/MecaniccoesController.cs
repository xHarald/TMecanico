using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMECANICO.Models;

namespace TMECANICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecaniccoesController : ControllerBase
    {
        private readonly TmecanicoContext _context;

        public MecaniccoesController(TmecanicoContext context)
        {
            _context = context;
        }

        // GET: api/Mecaniccoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanicco>>> GetMecaniccos()
        {
          if (_context.Mecaniccos == null)
          {
              return NotFound();
          }
            return await _context.Mecaniccos.ToListAsync();
        }

        // GET: api/Mecaniccoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanicco>> GetMecanicco(int id)
        {
          if (_context.Mecaniccos == null)
          {
              return NotFound();
          }
            var mecanicco = await _context.Mecaniccos.FindAsync(id);

            if (mecanicco == null)
            {
                return NotFound();
            }

            return mecanicco;
        }

        // PUT: api/Mecaniccoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanicco(int id, Mecanicco mecanicco)
        {
            if (id != mecanicco.IdMecanico)
            {
                return BadRequest();
            }

            _context.Entry(mecanicco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecaniccoExists(id))
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

        // POST: api/Mecaniccoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanicco>> PostMecanicco(Mecanicco mecanicco)
        {
          if (_context.Mecaniccos == null)
          {
              return Problem("Entity set 'TmecanicoContext.Mecaniccos'  is null.");
          }
            _context.Mecaniccos.Add(mecanicco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMecanicco", new { id = mecanicco.IdMecanico }, mecanicco);
        }

        // DELETE: api/Mecaniccoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanicco(int id)
        {
            if (_context.Mecaniccos == null)
            {
                return NotFound();
            }
            var mecanicco = await _context.Mecaniccos.FindAsync(id);
            if (mecanicco == null)
            {
                return NotFound();
            }

            _context.Mecaniccos.Remove(mecanicco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MecaniccoExists(int id)
        {
            return (_context.Mecaniccos?.Any(e => e.IdMecanico == id)).GetValueOrDefault();
        }
    }
}
