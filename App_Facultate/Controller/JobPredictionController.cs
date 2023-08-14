using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using System.Security.Cryptography.X509Certificates;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPredictionController : ControllerBase
    {
        private readonly FacultateContext _context;

        public JobPredictionController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/JobPrediction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category_Jobs>>> GetCategory_Jobs()
        {
            return await _context.Category_Jobs.ToListAsync();
        }

        // GET: api/JobPrediction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category_Jobs>> GetCategory_Jobs(int id)
        {
            var category_Jobs = await _context.Category_Jobs.FindAsync(id);

            if (category_Jobs == null)
            {
                return NotFound();
            }

            return category_Jobs;
        }

        // PUT: api/JobPrediction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory_Jobs(int id, Category_Jobs category_Jobs)
        {
            if (id != category_Jobs.id_category_job)
            {
                return BadRequest();
            }

            _context.Entry(category_Jobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Category_JobsExists(id))
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

        // POST: api/JobPrediction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category_Jobs>> PostCategory_Jobs(Category_Jobs category_Jobs, int id_user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Datele primite sunt invalide.");
            }

            var id_student = _context.Utilizatori.Where(s => s.id_utilizator.Equals(id_user))
                .Join(_context.Studenti,
                u => u.id_utilizator,
                s => s.id_utilizator, (u, s) => new
                { s, u }).Select(s => new { s.s.id_student }).ToList();

            // Obținem calificativele din baza de date pentru student
           // var calificative = _context.Utilizatori.Where(s => s.id_utilizator.Equals(id_user)).
               // Join(_context.Calificative,)



            _context.Category_Jobs.Add(category_Jobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory_Jobs", new { id = category_Jobs.id_category_job }, category_Jobs);
        }

        // DELETE: api/JobPrediction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory_Jobs(int id)
        {
            var category_Jobs = await _context.Category_Jobs.FindAsync(id);
            if (category_Jobs == null)
            {
                return NotFound();
            }

            _context.Category_Jobs.Remove(category_Jobs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Category_JobsExists(int id)
        {
            return _context.Category_Jobs.Any(e => e.id_category_job == id);
        }
    }
}
