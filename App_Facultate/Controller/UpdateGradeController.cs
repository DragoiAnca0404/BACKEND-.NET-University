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
    public class UpdateGradeController : ControllerBase
    {
        private readonly FacultateContext _context;

        public UpdateGradeController(FacultateContext context)
        {
            _context = context;
        }

        // PUT: api/Calificatives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificative(int id, Calificative calificative)
        {
            if (id != calificative.id_Calificativ)
            {
                return BadRequest();
            }

            _context.Entry(calificative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificativeExists(id))
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

        private bool CalificativeExists(int id)
        {
            return _context.Calificative.Any(e => e.id_Calificativ == id);
        }
    }
}
