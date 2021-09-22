using Commander.Model;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    //---> DbContext o sa generezi biblioteca EntityFrameworkCore
    //Conectarea la baza de date
    public class FacultateContext : DbContext
    {
        public FacultateContext(DbContextOptions<FacultateContext> opt) : base(opt)
        {

        }

        public DbSet<Specializari> Specializari { get; set; }
        public DbSet<Administratori> Administratori { get; set; }
        public DbSet<Calificative> Calificative { get; set; }
        public DbSet<Materii> Materii { get; set; }
        public DbSet<Profesori> Profesori { get; set; }
        public DbSet<Utilizatori> Utilizatori { get; set; }
        public DbSet<Studenti> Studenti { get; set; }




    }
}