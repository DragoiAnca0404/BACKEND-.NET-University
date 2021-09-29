using Commander.Data;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public String checkLogin(String username, [FromBody] String password)
        {
            return "Username-ul este : " + username + "si parola:" + password;
        }
    }
}