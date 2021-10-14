using Model;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    //---> DbContext o sa generezi biblioteca EntityFrameworkCore
    //Conectarea la baza de date
    public class FacultateContext : DbContext
    {
        public FacultateContext(DbContextOptions<FacultateContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 1, username = "MateiSolomon", nume = "Solomon", prenume = "Matei", parola = "matte777*", email = "matei_matt@yahoo.ro" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 2, username = "AnaMaria", nume = "Ion", prenume = "Ana-Maria", parola = "ana827272", email = "ana_maria@yahoo.com" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 3, username = "George0647", nume = "Ciobanu", prenume = "George", parola = "dogiuaaj922", email = "george_07@gmail.com" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 4, username = "FlorescuAndrei", nume = "Florescu", prenume = "Andrei", parola = "moviehsjjs", email = "flo_andrei@yahoo.com" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 5, username = "AnastasiaS", nume = "Soare", prenume = "Anastasia", parola = "sia73737*", email = "anastasia_sia@yahoo.ro" });

            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 1, denumire_specializare = "Finante" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 2, denumire_specializare = "Stiinte politice" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 3, denumire_specializare = "Drept administrativ" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 4, denumire_specializare = "Marketing" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 5, denumire_specializare = "Asistenta sociala" });

            modelBuilder.Entity<Studenti>().HasData(new Studenti {id_student=1, scutit_plata=true, id_specializare=1, id_utilizator=1 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 2, scutit_plata = false, id_specializare = 2, id_utilizator = 2 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 3, scutit_plata = false, id_specializare = 3, id_utilizator = 3 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 4, scutit_plata = true, id_specializare = 4, id_utilizator = 4 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 5, scutit_plata = false, id_specializare = 5, id_utilizator = 5 });

            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor=1, salariu=5000, grad= grad.Asistent_universitar, id_utilizator=1,id_materie=1});
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 2, salariu = 5800, grad = grad.Lector_universitar, id_utilizator = 2, id_materie = 2 });
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 3, salariu = 7830, grad = grad.Conferentiar_universitar, id_utilizator = 3, id_materie = 3 });
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 4, salariu = 4000, grad = grad.Profesor_universitar,id_utilizator = 4, id_materie = 4 });
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 5, salariu = 6700, grad = grad.Asistent_universitar,id_utilizator = 5, id_materie = 5 });

            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie =1, denumire_materie="Statistica economica" });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 2, denumire_materie = "Psihologie politica" });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 3, denumire_materie = "Bazele administratiei publice" });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 4, denumire_materie = "Tehnici promotionale" });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 5, denumire_materie = "Psihologie sociala" });

            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Specializare=1, nota=10, id_materie=1, id_student=1 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Specializare = 2, nota = 9.05, id_materie = 2, id_student = 2 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Specializare = 3, nota = 7.50, id_materie = 3, id_student = 3 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Specializare = 4, nota = 5.65, id_materie = 4, id_student = 4 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Specializare = 5, nota = 4.80, id_materie = 5, id_student = 5 });

            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator=1, id_utilizator=1 });
            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator = 2, id_utilizator = 2 });
            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator = 3, id_utilizator = 3 });
            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator = 4, id_utilizator = 4 });
            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator = 5, id_utilizator = 5 });

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