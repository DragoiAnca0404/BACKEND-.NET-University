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
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 6, username = "IonescuDenis", nume = "Ionescu", prenume = "Denis", parola = "boboc12345", email = "ionescu_denis@gmail.com" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 7, username = "PopAna", nume = "Pop", prenume = "Ana", parola = "pop1112", email = "pop_ana1999@yahoo.com" });
            modelBuilder.Entity<Utilizatori>().HasData(new Utilizatori { id_utilizator = 8, username = "TomaMihai", nume = "Toma", prenume = "Mihai", parola = "tom1112$", email = "toma_mihai@yahoo.com" });



            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 1, denumire_specializare = "Finante" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 2, denumire_specializare = "Stiinte politice" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 3, denumire_specializare = "Drept administrativ" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 4, denumire_specializare = "Marketing" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 5, denumire_specializare = "Asistenta sociala" });
            modelBuilder.Entity<Specializari>().HasData(new Specializari { id_Specializare = 6, denumire_specializare = "Computer science" });


            modelBuilder.Entity<Studenti>().HasData(new Studenti {id_student=1, scutit_plata=true, id_specializare=1, id_utilizator=1 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 2, scutit_plata = false, id_specializare = 2, id_utilizator = 2 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 3, scutit_plata = false, id_specializare = 3, id_utilizator = 6 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 4, scutit_plata = true, id_specializare = 4, id_utilizator = 7 });
            modelBuilder.Entity<Studenti>().HasData(new Studenti { id_student = 5, scutit_plata = true, id_specializare = 6, id_utilizator = 8 });


            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor=1, salariu=5000, grad= grad.Asistent_universitar, id_utilizator=3,id_materie=1});
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 2, salariu = 5800, grad = grad.Lector_universitar, id_utilizator = 4, id_materie = 2 });
            modelBuilder.Entity<Profesori>().HasData(new Profesori { id_profesor = 3, salariu = 7800, grad = grad.Profesor_universitar, id_utilizator = 4, id_materie = 2 });


            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie =1, denumire_materie="Statistica economica", id_student = 1 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 2, denumire_materie = "Psihologie politica", id_student = 2 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 3, denumire_materie = "Bazele administratiei publice", id_student = 3 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 4, denumire_materie = "Tehnici promotionale", id_student = 3 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 5, denumire_materie = "Psihologie sociala",  id_student = 4 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 6, denumire_materie = "Psihologie politica", id_student = 3 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 7, denumire_materie = "Psihologie politica", id_student = 4 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 8, denumire_materie = "Psihologie politica", id_student = 1 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 9, denumire_materie = "Sisteme de gestiune a bazelor de date", id_student = 5 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 10, denumire_materie = "Dezvoltarea aplicatiilor Web", id_student = 5 });
            modelBuilder.Entity<Materii>().HasData(new Materii { id_materie = 11, denumire_materie = "Programare orientata obiect - Java", id_student = 5 });




            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 1, nota = 10, CurrentDateGrade= "10-12-2023", id_materie = 1, id_student = 1 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 2, nota = 9.05, CurrentDateGrade = "10-12-2023", id_materie = 2, id_student = 2 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 3, nota = 8.55, CurrentDateGrade = "10-12-2023", id_materie = 2, id_student = 3 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 4, nota = 10, CurrentDateGrade = "10-12-2023", id_materie = 1, id_student = 3 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 5, nota = 5, CurrentDateGrade = "10-12-2023", id_materie = 2, id_student = 4 });

            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 6, nota = 9.8, CurrentDateGrade = "8-12-2023", id_materie = 9, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 7, nota = 7, CurrentDateGrade = "10-10-2023", id_materie = 9, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 8, nota = 6.5, CurrentDateGrade = "17-07-2023", id_materie = 9, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 9, nota = 8.5, CurrentDateGrade = "14-06-2023", id_materie = 10, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 10, nota = 5.1, CurrentDateGrade = "20-06-2023", id_materie = 10, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 11, nota = 9.5, CurrentDateGrade = "30-04-2023", id_materie = 11, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 12, nota = 7.8, CurrentDateGrade = "15-05-2023", id_materie = 11, id_student = 5 });
            modelBuilder.Entity<Calificative>().HasData(new Calificative { id_Calificativ = 13, nota = 4.8, CurrentDateGrade = "04-04-2023", id_materie = 11, id_student = 5 });



            modelBuilder.Entity<Administratori>().HasData(new Administratori { id_administrator=1, id_utilizator=5 });


            modelBuilder.Entity<Orar>().HasData(new Orar { id_orar = 1, ziua = ziua.Monday, Time_start = "08:00", Time_end = "09:50", id_materie = 1 });
            modelBuilder.Entity<Orar>().HasData(new Orar { id_orar = 2, ziua = ziua.Monday, Time_start = "10:00", Time_end = "11:50", id_materie = 1 });
            modelBuilder.Entity<Orar>().HasData(new Orar { id_orar = 3, ziua = ziua.Monday, Time_start = "12:00", Time_end = "13:50", id_materie = 1 });
            modelBuilder.Entity<Orar>().HasData(new Orar { id_orar = 4, ziua = ziua.Monday, Time_start = "14:00", Time_end = "15:50", id_materie = 1 });
            modelBuilder.Entity<Orar>().HasData(new Orar { id_orar = 5, ziua = ziua.Monday, Time_start = "16:00", Time_end = "17:50", id_materie = 1 });

            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 4, denumire_categorie_job = "Data Analyst" });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 3, denumire_categorie_job = "Frontend DEVELOPER" });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 2, denumire_categorie_job = "Backend DEVELOPER" });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 1, denumire_categorie_job = "Software Development" });


            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job=4, id_materie= 9, id_subject_category= 1 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 2, id_materie = 9, id_subject_category = 2 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 3, id_materie = 10, id_subject_category = 3 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 1, id_materie = 11, id_subject_category = 4 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 2, id_materie = 10, id_subject_category = 5 });

        }

        public DbSet<Specializari> Specializari { get; set; }
        public DbSet<Administratori> Administratori { get; set; }
        public DbSet<Calificative> Calificative { get; set; }
        public DbSet<Materii> Materii { get; set; }
        public DbSet<Profesori> Profesori { get; set; }
        public DbSet<Utilizatori> Utilizatori { get; set; }
        public DbSet<Studenti> Studenti { get; set; }
        public DbSet<Orar> Orar { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Category_Jobs> Category_Jobs { get; set; }
        public DbSet<subject_category> subject_category { get; set; }




    }
}