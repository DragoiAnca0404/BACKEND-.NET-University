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

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificative>> GetCalificative(int id)
        {
            var inspection = await _context.Calificative.FindAsync(id);

            if (inspection == null)
            {
                return NotFound();
            }

            return inspection;
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
                b=> b.id_utilizator,(a,b) => new {a,b}).Select(z=> new {grade= z.a.x.s.nota,name= z.b.nume,surname=z.b.prenume }).ToList();


            return Ok(grades);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Materii>>> PostAddGrade(int id_materie, string denumire_materie, string nume, string prenume, Calificative grade )
        {

            // var grades = _context.Materii.Where(w => w.denumire_materie.Equals(denumire_materie));


            //  _context.Calificative.Add(grade);


            //  await _context.SaveChangesAsync();

            // return CreatedAtAction("GetCalificative", new { id = grade.id_Calificativ }, grade);

           
                var dept = new Calificative()
                {
                    nota = 5,
                };
                _context.Entry(dept).State = EntityState.Added;
                _context.SaveChanges();
            

            return Ok();
        }




    }
}
