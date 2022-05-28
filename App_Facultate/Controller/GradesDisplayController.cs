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
            return await _context.Materii.ToListAsync();
        }

      
    }
}
