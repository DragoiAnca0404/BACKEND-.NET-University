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
    public class DisplayStudentsController : ControllerBase
    {
        private readonly FacultateContext _context;

        public DisplayStudentsController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/DisplayStudents
     

        // GET: api/DisplayStudents
        [HttpGet]
        public async Task<ActionResult<Materii>> GetMaterii(string denumire_materie)
        {
            var students = _context.Materii.Where(w => w.denumire_materie.Equals(denumire_materie))
                           .Join(_context.Studenti,
                           x => x.id_student,
                           y => y.id_student,
                            (x, y) => new { x, y }).Join(_context.Utilizatori,
                           a => a.y.id_utilizator,
                           b => b.id_utilizator, (a, b) => new { a, b }).Select(z => new {  name = z.b.nume, surname = z.b.prenume, id_user = z.a.y.id_utilizator, id_student = z.a.x.id_student }).ToList();

            return Ok(students);
        }

    }
}
