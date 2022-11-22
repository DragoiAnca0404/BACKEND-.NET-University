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
    public class GradesDisplayController : ControllerBase
    {
        private readonly FacultateContext _context;

        public GradesDisplayController(FacultateContext context)
        {
            _context = context;
        }

    
        // GET: api/GradesDisplay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materii>>> GetMaterii(string denumire_materie)
        {
            var grades = _context.Materii.Where(w => w.denumire_materie.Equals(denumire_materie))
                .Join(_context.Calificative,
                u => u.id_materie,
                s => s.id_materie,
                (u, s) => new
                { s, u }).Join(_context.Studenti,
                x => x.s.id_student,
                y => y.id_student,
                (x,y) => new {x,y}).Join(_context.Utilizatori,
                a=> a.y.id_utilizator,
                b=> b.id_utilizator,(a,b) => new {a,b}).Select(z=> new { id_grade = z.a.x.s.id_Calificativ, grade = z.a.x.s.nota, name= z.b.nume,surname=z.b.prenume, id_user=z.a.x.s.id_student }).ToList();


             return Ok(grades);
        }
    }
}