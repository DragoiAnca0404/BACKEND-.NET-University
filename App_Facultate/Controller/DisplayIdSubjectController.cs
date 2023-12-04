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
    public class DisplayIdSubjectController : ControllerBase
    {
        private readonly FacultateContext _context;

        public DisplayIdSubjectController(FacultateContext context)
        {
            _context = context;
        }

        // GET: api/DisplayIdSubject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materii>>> GetMaterii(string denumire_materie)
        {
            var id_subject = _context.Materii.Where(s => s.denumire_materie.Equals(denumire_materie)).Select(s => new { id_materie = s.id_materie }).FirstOrDefault();

            return Ok(id_subject); ;

        }   
    }
}