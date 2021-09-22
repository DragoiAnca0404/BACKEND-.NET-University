using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commander.Data;
using Commander.Model;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorisController : ControllerBase
    {
        private readonly FacultateContext _context;

        public UtilizatorisController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/Utilizatoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizatori>>> GetUtilizatori()
        {
            return await _context.Utilizatori.ToListAsync();
        }

        // GET: api/Utilizatoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizatori>> GetUtilizatori(int id)
        {
            var utilizatori = await _context.Utilizatori.FindAsync(id);

            if (utilizatori == null)
            {
                return NotFound();
            }

            return utilizatori;
        }

        // PUT: api/Utilizatoris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizatori(int id, Utilizatori utilizatori)
        {
            if (id != utilizatori.id_utilizator)
            {
                return BadRequest();
            }

            _context.Entry(utilizatori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizatoriExists(id))
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

        // POST: api/Utilizatoris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilizatori>> PostUtilizatori(Utilizatori utilizatori)
        {
            _context.Utilizatori.Add(utilizatori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizatori", new { id = utilizatori.id_utilizator }, utilizatori);
        }

        // DELETE: api/Utilizatoris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizatori(int id)
        {
            var utilizatori = await _context.Utilizatori.FindAsync(id);
            if (utilizatori == null)
            {
                return NotFound();
            }

            _context.Utilizatori.Remove(utilizatori);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizatoriExists(int id)
        {
            return _context.Utilizatori.Any(e => e.id_utilizator == id);
        }
    }
}
