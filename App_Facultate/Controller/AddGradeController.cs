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

namespace App_Facultate.Controller
{
    [Route("api/")]
    [ApiController]
    public class AddGradeController : ControllerBase
    {
        private readonly FacultateContext _context;


        public AddGradeController(FacultateContext context)
        {
            _context = context;

        }

        [HttpPost("add/")]
        public IActionResult PostMaterii(AddGrade item)
        {
            int id_user;
            double grade;
            string denumire_materie;
            string data_nota;

            grade = item.grade;
            id_user = item.id_user;
            denumire_materie=item.denumire_materie;
            data_nota = item.data_nota;
      

             var id_subject = _context.Materii.Where(s => s.denumire_materie.Equals(denumire_materie)).Select(s => new { id_materie = s.id_materie }).FirstOrDefault();
             var id_student = _context.Utilizatori.Where(s => s.id_utilizator.Equals(id_user))
                 .Join(_context.Studenti,
                 u => u.id_utilizator,
                 s => s.id_utilizator, (u, s) => new
                 { s, u }).Select(s => new { s.s.id_student }).ToList();

                 var add_grade = new Models.Calificative()
                 {
                     nota = grade,
                     id_materie = id_subject.id_materie,
                     id_student = id_user,
                     CurrentDateGrade= data_nota,
                 };
                 _context.Entry(add_grade).State = EntityState.Added;
                 _context.SaveChanges();

            return Ok(add_grade);           
        }
    }
}