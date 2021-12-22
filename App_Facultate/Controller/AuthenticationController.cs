using App_Facultate.Utils;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Authentication.Controller
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly FacultateContext _context;
        private readonly IConfiguration _config;

        public AuthenticationController(FacultateContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

       [HttpPost("login/")]
        public IActionResult checkLogin(string username, [FromBody]JsonElement passwordJson)
        {
            string password = passwordJson.GetProperty("password").GetString();
            var user = _context.Utilizatori.Where(s => s.username.Equals(username) && s.parola.Equals(password)).ToList();


            if (user.Count().Equals(0))
            {
                return BadRequest(new { message = "Login or password is incorrect" });

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


            if ((student.FirstOrDefault() !=null) && user.FirstOrDefault().id_utilizator.Equals(student.FirstOrDefault().id_utilizator))
            {
                response.Rol = "Student";
            }
            else if ((profesor.FirstOrDefault() != null) && user.First().id_utilizator.Equals(profesor.FirstOrDefault().id_utilizator))
            {
                response.Rol = "Profesor";

            }
            else if ((admin.FirstOrDefault() != null) && user.First().id_utilizator.Equals(admin.FirstOrDefault().id_utilizator))
            {
                response.Rol = "Administrator";
            }

            if (student.Count().Equals(1) || admin.Count().Equals(1) || profesor.Count().Equals(1)) 
            {
                var claims = new[]
                 {
                    new Claim (JwtRegisteredClaimNames.Sub, user.First().username),
                    new Claim (JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xecretKeywqejane"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken(
                    issuer: _config["Tokens:Issuer"],
                    audience: _config["Tokens:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(12),
                    signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Name = response.Nume,
                    Surname = response.Prenume,
                    Role = response.Rol
                });

#pragma warning disable CS0162 // Unreachable code detected
                return BadRequest("Failed to generate Token");
#pragma warning restore CS0162 // Unreachable code detected


            }

            return NotFound();
        }
    }
}