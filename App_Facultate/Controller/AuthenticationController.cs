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
            var userExists = _context.Utilizatori
                .Where(s => s.username.Equals(username) && s.parola.Equals(password))
                .Select(s => new
            {
                parola = s.parola,
                username = s.prenume
            }).Count();

            var userId = _context.Utilizatori
                .Where(s => s.username.Equals(username) && s.parola.Equals(password))
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            var studentId = _context.Studenti
                .Select(s => new
                {
                    id_utilizatori = s.id_utilizatori
                });

            var adminId = _context.Administratori
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });
            var profesorId = _context.Profesori
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });
            
            if (userId == studentId)
            {
            }
             else if (userId == adminId)
            {

            }
             else if (userId == profesorId)
            {

            }
             else
            {
                return NotFound();
            }
            return userExists.Equals(1) ? Ok("User-ul exista!") : NotFound();
        }
    }
}