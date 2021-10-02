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
        public String checkLogin(String username)
        {
            // return _context.Utilizatori.FromSqlRaw("SELECT username FROM Utilizatori")
            //     .ToString();
            //  return "Username-ul este : " + username + "si parola:" + password;

            //_context.Utilizatori.FromSqlRaw("SELECT * FROM Utilizatori").ToList();

             var name = _context.Utilizatori.Find(1).email;

            /*var name = _context.Utilizatori.Select(s => new
            {
                nume = s.nume,
                username = s.prenume
            });*/




            return "ac";
        }
    }
}