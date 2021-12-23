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
        public async Task<ActionResult<IEnumerable<Utilizatori>>> GetUtilizatori()
        {

            /* var student = _context.Utilizatori.Join(_context.Studenti,
                            u => u.id_utilizator,
                            s => s.id_utilizator,
                            (u, s) => new
                            {
                                s = s.scutit_plata,
                                u = u.nume,
                            }).ToList();*/

            var admin = _context.Utilizatori.Select(s => new {nume = s.nume, prenume = s.prenume, email = s.email });


            /* var student = _context.Utilizatori.Join(_context.Studenti,
                               u => u.id_utilizator,
                               s => s.id_utilizator,
                               (u, s) => s)
                               
            /*var student = _context.Utilizatori.Join(_context.Studenti,
                              u => u.id_utilizator,
                              s => s.id_utilizator,
                              (u, s) => new { u=u.nume }).Join(_context.Specializari, j => j.id_specializare, i => i.id_Specializare, (i, j) => new { i=i.scutit_plata, j=j.denumire_specializare}).ToList();*/
            
            var student = _context.Utilizatori.Join(_context.Studenti,
                            u => u.id_utilizator,
                            s => s.id_utilizator,
                            (u, s) => new
                            {s, u})
                            .Join(_context.Specializari, j =>j.s.id_specializare, i=>i.id_Specializare, (j,i)=>new { j,i})
                            .Select(x => new { plata = x.j.s.scutit_plata, nume = x.j.u.nume, prenume =x.j.u.prenume, email =x.j.u.email , specializare = x.i.denumire_specializare } ).ToList();

            return null;
        }
    }
}
