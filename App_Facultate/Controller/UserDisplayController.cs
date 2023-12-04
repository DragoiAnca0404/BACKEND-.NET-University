using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Model;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDisplayController : ControllerBase
    {
        private readonly FacultateContext _context;

        public UserDisplayController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/UserDisplay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizatori>>> GetUtilizatori(string username)
        {
            var admin = _context.Utilizatori.Where(s => s.username.Equals(username)).Join(_context.Administratori,
                            u => u.id_utilizator,
                            s => s.id_utilizator,
                            (u, s) => new
                            { s, u }).
                Select(s => new {name = s.u.nume, surname = s.u.prenume, email = s.u.email }).ToList();


            var student = _context.Utilizatori.Where(s => s.username.Equals(username))
                .Join(_context.Studenti,
                            u => u.id_utilizator,
                            s => s.id_utilizator,
                            (u, s) => new
                            {s, u})
                            .Join(_context.Specializari, j =>j.s.id_specializare, i=>i.id_Specializare, (j,i)=>new { j,i})
                            .Select(x => new { pay = x.j.s.scutit_plata, name = x.j.u.nume, surname =x.j.u.prenume, email =x.j.u.email , specializare = x.i.denumire_specializare } ).ToList();

            var teacher = _context.Utilizatori
                .Where(s => s.username.Equals(username))
                .Join(_context.Profesori,
                u => u.id_utilizator,
                s => s.id_utilizator,
                (u, s) => new { s, u })
                .Join(_context.Materii, i => i.s.id_materie, j => j.id_materie, (i, j) => new { j, i })
                .Select(x => new { course = x.j.denumire_materie, degree = x.i.s.grad, name = x.i.u.nume, surname = x.i.u.prenume, email = x.i.u.email }).ToList();

            if (admin.Count().Equals(1))
            {
                return Ok(admin);
            }
            else if (student.Count().Equals(1))
            {
                return Ok(student);
            }
            else if (teacher.Count().Equals(1))
            {
                return Ok(teacher);
            }
            return NotFound();
        }
    }
}