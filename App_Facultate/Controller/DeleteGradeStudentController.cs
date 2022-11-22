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
    public class DeleteGradeStudentController : ControllerBase
    {
        private readonly FacultateContext _context;

        public DeleteGradeStudentController(FacultateContext context)
        {
            _context = context;
        }

        // DELETE: api/DeleteGradeStudent/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCalificative(int id)
        {
            var calificative = await _context.Calificative.FindAsync(id);
            if (calificative == null)
            {
                return NotFound();
            }

            _context.Calificative.Remove(calificative);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
