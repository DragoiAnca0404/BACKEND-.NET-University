using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayIdSubjectController : ControllerBase
    {
        private readonly FacultateContext _context;

        public DisplayIdSubjectController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/DisplayIdSubject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materii>>> GetMaterii(string denumire_materie)
        {
            var id_subject = _context.Materii.Where(s => s.denumire_materie.Equals(denumire_materie)).Select(s => new { id_materie = s.id_materie }).FirstOrDefault();

            return Ok(id_subject); ;

        }



        // PUT: api/DisplayIdSubject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterii(int id, Materii materii)
        {
            if (id != materii.id_materie)
            {
                return BadRequest();
            }

            _context.Entry(materii).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriiExists(id))
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

        // POST: api/DisplayIdSubject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materii>> PostMaterii(Materii materii)
        {
            _context.Materii.Add(materii);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterii", new { id = materii.id_materie }, materii);
        }

        // DELETE: api/DisplayIdSubject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterii(int id)
        {
            var materii = await _context.Materii.FindAsync(id);
            if (materii == null)
            {
                return NotFound();
            }

            _context.Materii.Remove(materii);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriiExists(int id)
        {
            return _context.Materii.Any(e => e.id_materie == id);
        }
    }
}
