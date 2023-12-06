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

        public FacultateContext()
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

            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 4, denumire_categorie_job = "Data Analyst", quality= "Writing and communication, Statistical knowledge, Problem-solving skills, Creating dashboards and reports", descriere_job= "În mod succint, un analist de date colectează, analizează și interpretează date pentru a oferi informații valoroase în procesul decizional al unei organizații. Pentru a deveni un astfel de profesionist, trebuie să înveți să:\r\n\r\n", atributii_job= "Analizezi datele folosind statistici și matematică.\r\nProgramezi, în special în limbaje precum Python sau R.\r\nLucrezi cu baze de date și cunoști limbajul SQL.\r\nCreezi vizualizări pentru a prezenta rezultatele.\r\nFolosești instrumente precum Excel, Pandas, NumPy pentru analiză.\r\nÎnțelegi conceptele statistice de bază." });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 3, denumire_categorie_job = "Frontend DEVELOPER", quality = "Writing and communication,UI/UX Design Skills, Problem-solving skills, Gândire analitică, Javascript, CSS, HTML, Framework", descriere_job = "Un dezvoltator de frontend este responsabil pentru crearea și implementarea componentelor vizuale ale unei aplicații web sau mobile.Pentru a deveni un dezvoltator de frontend, trebuie să înveți următoarele:\r\n\r\n", atributii_job= "HTML: Înțelegerea structurii paginilor web folosind limbajul de marcă HTML pentru a defini elementele.\r\n\r\nCSS: Cunoașterea stilurilor de formatare și design folosind CSS pentru a da aspectul dorit paginilor web.\r\n\r\nJavaScript: Învățarea limbajului de programare JavaScript pentru adăugarea de interactivitate și funcționalități la paginile web.\r\n\r\nResponsive Design: Abilitatea de a crea pagini web care se adaptează la diferite dimensiuni de ecran (dispozitive desktop, tablete, telefoane mobile).\r\n\r\nFramework-uri Frontend: Cunoașterea unor cadre de lucru precum React, Angular sau Vue.js pentru dezvoltarea mai eficientă și organizată a interfețelor.\r\n\r\nVersion Control/Git: Înțelegerea sistemelor de control al versiunilor, cum ar fi Git, pentru colaborare și gestionarea eficientă a codului. " });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 2, denumire_categorie_job = "Backend DEVELOPER", quality = "Writing and communication, Familiarity with Servers, Problem-solving skills, Team player, Knowledge of APIs", descriere_job = "Un dezvoltator de backend este responsabil pentru partea din spate a unei aplicații, care gestionează logica, stocarea datelor și comunicarea cu serverul. Pentru a deveni un dezvoltator de backend, trebuie să înveți următoarele:\r\n\r\n ", atributii_job= "Limbaje de programare: Stăpânește cel puțin un limbaj de programare folosit în dezvoltarea backend, cum ar fi Python, Java, PHP, Ruby, Node.js, Go, etc.\r\n\r\nBaze de date: Înțelege conceptele bazelor de date și cunoaște SQL pentru a manipula și stoca datele în mod eficient.\r\n\r\nAPI-uri: Învățați să creați și să gestionați API-uri (Application Programming Interfaces) pentru a permite comunicația între frontend și backend.\r\n\r\nFramework-uri: Folosește cadre de lucru backend precum Django (Python), Ruby on Rails (Ruby), Spring (Java), Express.js (Node.js) pentru a dezvolta rapid și eficient. " });
            modelBuilder.Entity<Category_Jobs>().HasData(new Category_Jobs { id_category_job = 1, denumire_categorie_job = "Software Development", quality = "Writing and communication, Statistical knowledge, Problem-solving skills, Programming Languages, Team player, Algorithm and Data Structures", descriere_job= "Dezvoltarea software implică creația, proiectarea și menținerea aplicațiilor și programelor informatice. Acest proces se referă la transformarea cerințelor și nevoilor utilizatorilor în soluții tehnice funcționale și utile. Iată o privire de ansamblu asupra dezvoltării software și ce presupune:\r\n\r\n ", atributii_job= "Analiza Cerințelor: Înțelegerea detaliată a cerințelor utilizatorilor și a contextului în care va fi utilizat software-ul.\r\n\r\nProiectarea: Crearea unui plan sau unui design al arhitecturii și a funcționalităților software-ului.\r\n\r\nProgramare: Scrierea codului sursă folosind diverse limbaje de programare și tehnologii.\r\n\r\nTestare: Verificarea și validarea software-ului pentru a identifica erori și asigura funcționarea corectă.\r\n\r\nDebugging: Identificarea și corectarea erorilor și a problemelor de cod. " });

            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job=4, id_materie= 9, id_subject_category= 1 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 2, id_materie = 9, id_subject_category = 2 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 3, id_materie = 10, id_subject_category = 3 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 1, id_materie = 11, id_subject_category = 4 });
            modelBuilder.Entity<subject_category>().HasData(new subject_category { id_category_job = 2, id_materie = 10, id_subject_category = 5 });

            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 1, quality = "Gândire analitică", id_category_job = 1 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 2, quality = "Team player", id_category_job = 1 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 3, quality = "Problem-solving skills", id_category_job = 1 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 4, quality = "Organizat", id_category_job = 1 });

            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 12, quality = "Familiarity with Servers", id_category_job = 2 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 22, quality = "Team player", id_category_job = 2 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 32, quality = "Problem-solving skills", id_category_job = 2 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 42, quality = "Organizat", id_category_job = 2 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 43, quality = "Knowledge of APIs", id_category_job = 2 });

            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 13, quality = "HTML", id_category_job = 3 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 23, quality = "CSS", id_category_job = 3 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 33, quality = "Frameworks and Libraries", id_category_job = 3 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 47, quality = "JavaScript", id_category_job = 3 });

            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 15, quality = "Writing and communication", id_category_job = 4 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 25, quality = "Statistical knowledge", id_category_job = 4 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 35, quality = "Problem-solving skills", id_category_job = 4 });
            modelBuilder.Entity<Job_qualities>().HasData(new Job_qualities { id_job_quality = 45, quality = "Creating dashboards and reports", id_category_job = 4 });
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
        public DbSet<Job_qualities> Job_qualities { get; set; }

    }
}