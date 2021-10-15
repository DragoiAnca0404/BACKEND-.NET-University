using App_Facultate.Utils;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
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
            var user = _context.Utilizatori
                .Where(s => s.username.Equals(username) && s.parola.Equals(password))
                .ToList();

            if (user.Count().Equals(0))
            {
                return NotFound("No such user!");
            }

            var response = new LoginResponse();
            response.Nume = user.First().nume;
            response.Prenume = user.First().prenume;

            var student = _context.Studenti
                .Where(s => s.id_utilizator.Equals(user.First().id_utilizator))
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            var profesor = _context.Profesori
                .Where(s => s.id_utilizator.Equals(user.First().id_utilizator))
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            var admin = _context.Administratori
                .Where(s => s.id_utilizator.Equals(user.First().id_utilizator))
                .Select(s => new
                {
                    id_utilizator = s.id_utilizator
                });

            if (student.Count().Equals(1))
            {
                if (user.First().id_utilizator.Equals(student.First().id_utilizator))
                {
                    response.Rol = "Student";
                    return Ok(response);
                }
            }

            if (profesor.Count().Equals(1))
            {
                if (user.First().id_utilizator.Equals(profesor.First().id_utilizator))
                {
                    response.Rol = "Profesor";
                    return Ok(response);
                }
            }

            if (admin.Count().Equals(1))
            {
                if (user.First().id_utilizator.Equals(admin.First().id_utilizator))
                {
                    response.Rol = "Administrator";
                    return Ok(response);
                }
            }

            return NotFound();
        }
    }
}