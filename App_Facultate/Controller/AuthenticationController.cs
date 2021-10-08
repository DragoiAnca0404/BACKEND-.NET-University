using Commander.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Authentication.Controller
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly FacultateContext _context;

        public AuthenticationController(FacultateContext context)
        {
            _context = context;
        }

        [HttpGet("login/")]
        public IActionResult checkLogin(String username, [FromBody] String password)
        {            
            var userId = _context.Utilizatori
                .Where(s => s.username.Equals(username) && s.parola.Equals(password))
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            if (userId == null)
            {
                return NotFound();
            }

            var studentId = _context.Studenti
                .Select(s => new
                {
                    id_utilizatori = s.id_utilizatori
                });

            if (userId == studentId)
            {
                return Ok("Student");
            }

            var adminId = _context.Administratori
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            if (userId == adminId)
            {
                return Ok("Administrator");

            }

            var profesorId = _context.Profesori
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });
            

            if (userId == profesorId)
            {
                return Ok("Profesor");
            }

            return NotFound();
        }
    }
}