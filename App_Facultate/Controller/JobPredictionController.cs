using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace App_Facultate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPredictionController : ControllerBase
    {
        private readonly FacultateContext _context;

        public JobPredictionController(FacultateContext context)
        {
            _context = context;
        }

        public class JobCategory
        {
            public string Job { get; set; }
            public string Quality { get; set; }
        }


        // GET: api/JobPrediction/5
        [HttpGet]
        public async Task<ActionResult<List<object>>> GetCategory_Jobs(string username)
        {
            var id_student = _context.Utilizatori.Where(x => x.username.Equals(username)).
                Join(_context.Studenti,
                s => s.id_utilizator,
                w => w.id_utilizator,
                (s, w) => new { s, w }).Select(y => new { id_student = y.w.id_student }).ToList();

            var category_Jobs = await _context.Category_Jobs.FindAsync(id_student.First().id_student);

            var grades_subjects = _context.Calificative
       .Where(w => w.id_student.Equals(id_student.First().id_student))
       .Join(_context.Materii,
             u => u.id_materie,
             s => s.id_materie,
             (u, s) => new { u, s })
       .GroupBy(z => z.s.denumire_materie)
       .Select(group => new
       {
           denumire_materie = group.Key,
           average_grade = group.Average(item => item.u.nota)
       })
       .OrderByDescending(item => item.average_grade)
       .ToList();

            string result = "";
            string message = "";

            List<object> resultItems = new List<object>();

            List<string> highPerformingSubjects = new List<string>();
            bool foundExceptional = false;
            bool evaluatedExceptionalTwo = false;
            bool evaluatedExceptional3 = false;
            bool evaluatedExceptional4 = false;

            foreach (var grade_subject in grades_subjects)
            {
                double averageGrade = grade_subject.average_grade;

                if (averageGrade >= 9 && averageGrade <= 10 && !foundExceptional)
                {
                    evaluatedExceptionalTwo = true;
                    var jobs_category = GetJobsCategory(grade_subject.denumire_materie);
                    resultItems.AddRange(jobs_category);
                    message = "Felicitari ai rezultate exceptionale!";
                }
                else if (averageGrade >= 7 && averageGrade < 9 && !foundExceptional && !evaluatedExceptionalTwo)
                {
                    evaluatedExceptional3 = true;
                    var jobs_category = GetJobsCategory(grade_subject.denumire_materie);
                    resultItems.AddRange(jobs_category);
                    message = "Ai note foarte bune, inca un pic efort si atingi perfectiunea.";
                }
                else if (averageGrade >= 6 && averageGrade < 8 && !evaluatedExceptionalTwo && !evaluatedExceptional3 && !foundExceptional)
                {
                    evaluatedExceptional4 = true;
                    var jobs_category = GetJobsCategory(grade_subject.denumire_materie);
                    resultItems.AddRange(jobs_category);
                    message = "Notele tale sunt satisfacatoare, dar cu putin efort poti obtine note mai bune.";
                }
                else if (averageGrade >= 1 && averageGrade < 6 && !evaluatedExceptionalTwo && !evaluatedExceptional3 && !foundExceptional && !evaluatedExceptional4)
                {
                    result = "Fail";
                    message = "Imi pare rau, dar notele tale actuale nu pot defini ce joburi ti se potrivesc momentan.";
                    return Ok(new { Message = message, Result = result });
                }
            }
            return Ok(new { Message = message, Result = resultItems });
        }


        private List<object> GetJobsCategory(string denumireMaterie)
        {
            return _context.Materii
                .Where(w => w.denumire_materie.Equals(denumireMaterie))
                .Join(_context.subject_category,
                    u => u.id_materie,
                    s => s.id_materie,
                    (u, s) => new { u, s })
                .Join(_context.Category_Jobs,
                    a => a.s.id_category_job,
                    b => b.id_category_job,
                    (a, b) => new { a, b })
                .Select(group => new
                {
                    job = group.b.denumire_categorie_job,
                    quality = group.b.quality,
                    descriere = group.b.descriere_job,
                    atributii = group.b.atributii_job
                })
                .ToList<object>();
        }
    }
}