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
        //public String checkLogin(String username, [FromBody] String password)
        public String checkLogin(String username, [FromBody] String password)
        {
            // return _context.Utilizatori.FromSqlRaw("SELECT username FROM Utilizatori")
            //     .ToString();
            //  return "Username-ul este : " + username + "si parola:" + password;

            //_context.Utilizatori.FromSqlRaw("SELECT * FROM Utilizatori").ToList();

             //var name = _context.Utilizatori.Find(1).email;

            
            // lista de utilizatori
            var usersList = _context.Utilizatori.Select(s => new
            {
                nume = s.nume,
                username = s.prenume
            });


            // numar de utilizatori
            var count = _context.Utilizatori.Select(s => new
            {
                nume = s.nume,
                username = s.prenume
            }).Count();

            var findUsers = _context.Utilizatori
                .Where(s => s.username == username)
                .Select(s => new
            {
                parola = s.parola,
                username = s.prenume
            }).Count();

            return "ac";
        }
    }
}