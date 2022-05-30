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

        // POST: api/GradesDisplay
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Materii>>> PostAddGrade(string denumire_materie, string nume, string surname, double grade )
        {
            var id_subject = _context.Materii.Where(s => s.denumire_materie.Equals(denumire_materie)).Select(s => new { id_materie = s.id_materie }).ToList();
            var id_student = _context.Utilizatori.Where(s => s.nume.Equals(nume) && s.prenume.Equals(surname))
                .Join(_context.Studenti,
                u => u.id_utilizator,
                s => s.id_utilizator, (u, s) => new
                { s, u }).Select(s => new { s.s.id_student}).ToList();




                    var add_grade = new Calificative()
            {
                nota = grade,
                id_materie = id_subject[0].id_materie,
                id_student = id_student[0].id_student
            };
                _context.Entry(add_grade).State = EntityState.Added;
                _context.SaveChanges();
            
            return Ok(add_grade);
        }




    }
}
