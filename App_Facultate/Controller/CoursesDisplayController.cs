using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Microsoft.Extensions.Configuration;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesDisplayController : ControllerBase
    {
        private readonly FacultateContext _context;
        public CoursesDisplayController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/CoursesDisplay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materii>>> GetMaterii(string username)
        {

            var courses = _context.Materii.Join(_context.Profesori,
                u => u.id_materie,
                            s => s.id_materie,
                            (u, s) => new
                            { s, u }).Join(_context.Utilizatori, x=>x.s.id_utilizator, y=>y.id_utilizator, (x, y) => new { x,y}).Where(w=>w.y.username.Equals(username)).
                            Select(z => new
                            { denumire_materie = z.x.u.denumire_materie }).ToList();

            return Ok(courses);
        }  
    }
}
