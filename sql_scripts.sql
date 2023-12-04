IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category_Jobs] (
    [id_category_job] int NOT NULL IDENTITY,
    [denumire_categorie_job] nvarchar(250) NOT NULL,
    [quality] nvarchar(250) NOT NULL,
    [descriere_job] nvarchar(max) NOT NULL,
    [atributii_job] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Category_Jobs] PRIMARY KEY ([id_category_job])
);
GO

CREATE TABLE [Specializari] (
    [id_Specializare] int NOT NULL IDENTITY,
    [denumire_specializare] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Specializari] PRIMARY KEY ([id_Specializare])
);
GO

CREATE TABLE [Utilizatori] (
    [id_utilizator] int NOT NULL IDENTITY,
    [username] nvarchar(250) NOT NULL,
    [nume] nvarchar(250) NOT NULL,
    [prenume] nvarchar(250) NOT NULL,
    [parola] nvarchar(250) NOT NULL,
    [email] nvarchar(max) NULL,
    CONSTRAINT [PK_Utilizatori] PRIMARY KEY ([id_utilizator])
);
GO

CREATE TABLE [Job_qualities] (
    [id_job_quality] int NOT NULL IDENTITY,
    [quality] nvarchar(250) NOT NULL,
    [id_category_job] int NOT NULL,
    [Category_Jobsid_category_job] int NULL,
    CONSTRAINT [PK_Job_qualities] PRIMARY KEY ([id_job_quality]),
    CONSTRAINT [FK_Job_qualities_Category_Jobs_Category_Jobsid_category_job] FOREIGN KEY ([Category_Jobsid_category_job]) REFERENCES [Category_Jobs] ([id_category_job]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Jobs] (
    [id_job] int NOT NULL IDENTITY,
    [denumire_job] nvarchar(250) NOT NULL,
    [id_category_job] int NOT NULL,
    [Category_Jobsid_category_job] int NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([id_job]),
    CONSTRAINT [FK_Jobs_Category_Jobs_Category_Jobsid_category_job] FOREIGN KEY ([Category_Jobsid_category_job]) REFERENCES [Category_Jobs] ([id_category_job]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Administratori] (
    [id_administrator] int NOT NULL IDENTITY,
    [id_utilizator] int NOT NULL,
    [Utilizatoriid_utilizator] int NULL,
    CONSTRAINT [PK_Administratori] PRIMARY KEY ([id_administrator]),
    CONSTRAINT [FK_Administratori_Utilizatori_Utilizatoriid_utilizator] FOREIGN KEY ([Utilizatoriid_utilizator]) REFERENCES [Utilizatori] ([id_utilizator]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Studenti] (
    [id_student] int NOT NULL IDENTITY,
    [scutit_plata] bit NOT NULL,
    [id_specializare] int NOT NULL,
    [Specializariid_Specializare] int NULL,
    [id_utilizator] int NOT NULL,
    [Utilizatoriid_utilizator] int NULL,
    CONSTRAINT [PK_Studenti] PRIMARY KEY ([id_student]),
    CONSTRAINT [FK_Studenti_Specializari_Specializariid_Specializare] FOREIGN KEY ([Specializariid_Specializare]) REFERENCES [Specializari] ([id_Specializare]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Studenti_Utilizatori_Utilizatoriid_utilizator] FOREIGN KEY ([Utilizatoriid_utilizator]) REFERENCES [Utilizatori] ([id_utilizator]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Materii] (
    [id_materie] int NOT NULL IDENTITY,
    [denumire_materie] nvarchar(250) NOT NULL,
    [id_student] int NOT NULL,
    [Studentiid_student] int NULL,
    CONSTRAINT [PK_Materii] PRIMARY KEY ([id_materie]),
    CONSTRAINT [FK_Materii_Studenti_Studentiid_student] FOREIGN KEY ([Studentiid_student]) REFERENCES [Studenti] ([id_student]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Calificative] (
    [id_Calificativ] int NOT NULL IDENTITY,
    [nota] float NOT NULL,
    [CurrentDateGrade] nvarchar(250) NOT NULL,
    [id_materie] int NOT NULL,
    [Materiiid_materie] int NULL,
    [id_student] int NOT NULL,
    [Studentiid_student] int NULL,
    CONSTRAINT [PK_Calificative] PRIMARY KEY ([id_Calificativ]),
    CONSTRAINT [FK_Calificative_Materii_Materiiid_materie] FOREIGN KEY ([Materiiid_materie]) REFERENCES [Materii] ([id_materie]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Calificative_Studenti_Studentiid_student] FOREIGN KEY ([Studentiid_student]) REFERENCES [Studenti] ([id_student]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Orar] (
    [id_orar] int NOT NULL IDENTITY,
    [ziua] int NULL,
    [Time_start] nvarchar(max) NOT NULL,
    [Time_end] nvarchar(max) NOT NULL,
    [id_materie] int NOT NULL,
    [Materiiid_materie] int NULL,
    CONSTRAINT [PK_Orar] PRIMARY KEY ([id_orar]),
    CONSTRAINT [FK_Orar_Materii_Materiiid_materie] FOREIGN KEY ([Materiiid_materie]) REFERENCES [Materii] ([id_materie]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Profesori] (
    [id_profesor] int NOT NULL IDENTITY,
    [salariu] money NOT NULL,
    [grad] int NULL,
    [id_utilizator] int NOT NULL,
    [Utilizatoriid_utilizator] int NULL,
    [id_materie] int NOT NULL,
    [Materiiid_materie] int NULL,
    CONSTRAINT [PK_Profesori] PRIMARY KEY ([id_profesor]),
    CONSTRAINT [FK_Profesori_Materii_Materiiid_materie] FOREIGN KEY ([Materiiid_materie]) REFERENCES [Materii] ([id_materie]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Profesori_Utilizatori_Utilizatoriid_utilizator] FOREIGN KEY ([Utilizatoriid_utilizator]) REFERENCES [Utilizatori] ([id_utilizator]) ON DELETE NO ACTION
);
GO

CREATE TABLE [subject_category] (
    [id_subject_category] int NOT NULL IDENTITY,
    [id_materie] int NOT NULL,
    [Materiiid_materie] int NULL,
    [id_category_job] int NOT NULL,
    [Category_Jobsid_category_job] int NULL,
    CONSTRAINT [PK_subject_category] PRIMARY KEY ([id_subject_category]),
    CONSTRAINT [FK_subject_category_Category_Jobs_Category_Jobsid_category_job] FOREIGN KEY ([Category_Jobsid_category_job]) REFERENCES [Category_Jobs] ([id_category_job]) ON DELETE NO ACTION,
    CONSTRAINT [FK_subject_category_Materii_Materiiid_materie] FOREIGN KEY ([Materiiid_materie]) REFERENCES [Materii] ([id_materie]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_administrator', N'Utilizatoriid_utilizator', N'id_utilizator') AND [object_id] = OBJECT_ID(N'[Administratori]'))
    SET IDENTITY_INSERT [Administratori] ON;
INSERT INTO [Administratori] ([id_administrator], [Utilizatoriid_utilizator], [id_utilizator])
VALUES (1, NULL, 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_administrator', N'Utilizatoriid_utilizator', N'id_utilizator') AND [object_id] = OBJECT_ID(N'[Administratori]'))
    SET IDENTITY_INSERT [Administratori] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_Calificativ', N'CurrentDateGrade', N'Materiiid_materie', N'Studentiid_student', N'id_materie', N'id_student', N'nota') AND [object_id] = OBJECT_ID(N'[Calificative]'))
    SET IDENTITY_INSERT [Calificative] ON;
INSERT INTO [Calificative] ([id_Calificativ], [CurrentDateGrade], [Materiiid_materie], [Studentiid_student], [id_materie], [id_student], [nota])
VALUES (13, N'04-04-2023', NULL, NULL, 11, 5, 4.7999999999999998E0),
(12, N'15-05-2023', NULL, NULL, 11, 5, 7.7999999999999998E0),
(11, N'30-04-2023', NULL, NULL, 11, 5, 9.5E0),
(10, N'20-06-2023', NULL, NULL, 10, 5, 5.0999999999999996E0),
(9, N'14-06-2023', NULL, NULL, 10, 5, 8.5E0),
(8, N'17-07-2023', NULL, NULL, 9, 5, 6.5E0),
(7, N'10-10-2023', NULL, NULL, 9, 5, 7.0E0),
(6, N'8-12-2023', NULL, NULL, 9, 5, 9.8000000000000007E0),
(5, N'10-12-2023', NULL, NULL, 2, 4, 5.0E0),
(4, N'10-12-2023', NULL, NULL, 1, 3, 10.0E0),
(3, N'10-12-2023', NULL, NULL, 2, 3, 8.5500000000000007E0),
(1, N'10-12-2023', NULL, NULL, 1, 1, 10.0E0),
(2, N'10-12-2023', NULL, NULL, 2, 2, 9.0500000000000007E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_Calificativ', N'CurrentDateGrade', N'Materiiid_materie', N'Studentiid_student', N'id_materie', N'id_student', N'nota') AND [object_id] = OBJECT_ID(N'[Calificative]'))
    SET IDENTITY_INSERT [Calificative] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_category_job', N'atributii_job', N'denumire_categorie_job', N'descriere_job', N'quality') AND [object_id] = OBJECT_ID(N'[Category_Jobs]'))
    SET IDENTITY_INSERT [Category_Jobs] ON;
INSERT INTO [Category_Jobs] ([id_category_job], [atributii_job], [denumire_categorie_job], [descriere_job], [quality])
VALUES (1, CONCAT(CAST(N'Analiza Cerințelor: Înțelegerea detaliată a cerințelor utilizatorilor și a contextului în care va fi utilizat software-ul.' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N'Proiectarea: Crearea unui plan sau unui design al arhitecturii și a funcționalităților software-ului.', nchar(13), nchar(10), nchar(13), nchar(10), N'Programare: Scrierea codului sursă folosind diverse limbaje de programare și tehnologii.', nchar(13), nchar(10), nchar(13), nchar(10), N'Testare: Verificarea și validarea software-ului pentru a identifica erori și asigura funcționarea corectă.', nchar(13), nchar(10), nchar(13), nchar(10), N'Debugging: Identificarea și corectarea erorilor și a problemelor de cod. '), N'Software Development', CONCAT(CAST(N'Dezvoltarea software implică creația, proiectarea și menținerea aplicațiilor și programelor informatice. Acest proces se referă la transformarea cerințelor și nevoilor utilizatorilor în soluții tehnice funcționale și utile. Iată o privire de ansamblu asupra dezvoltării software și ce presupune:' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N' '), N'Writing and communication, Statistical knowledge, Problem-solving skills, Programming Languages, Team player, Algorithm and Data Structures'),
(2, CONCAT(CAST(N'Limbaje de programare: Stăpânește cel puțin un limbaj de programare folosit în dezvoltarea backend, cum ar fi Python, Java, PHP, Ruby, Node.js, Go, etc.' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N'Baze de date: Înțelege conceptele bazelor de date și cunoaște SQL pentru a manipula și stoca datele în mod eficient.', nchar(13), nchar(10), nchar(13), nchar(10), N'API-uri: Învățați să creați și să gestionați API-uri (Application Programming Interfaces) pentru a permite comunicația între frontend și backend.', nchar(13), nchar(10), nchar(13), nchar(10), N'Framework-uri: Folosește cadre de lucru backend precum Django (Python), Ruby on Rails (Ruby), Spring (Java), Express.js (Node.js) pentru a dezvolta rapid și eficient. '), N'Backend DEVELOPER', CONCAT(CAST(N'Un dezvoltator de backend este responsabil pentru partea din spate a unei aplicații, care gestionează logica, stocarea datelor și comunicarea cu serverul. Pentru a deveni un dezvoltator de backend, trebuie să înveți următoarele:' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N' '), N'Writing and communication, Familiarity with Servers, Problem-solving skills, Team player, Knowledge of APIs'),
(3, CONCAT(CAST(N'HTML: Înțelegerea structurii paginilor web folosind limbajul de marcă HTML pentru a defini elementele.' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N'CSS: Cunoașterea stilurilor de formatare și design folosind CSS pentru a da aspectul dorit paginilor web.', nchar(13), nchar(10), nchar(13), nchar(10), N'JavaScript: Învățarea limbajului de programare JavaScript pentru adăugarea de interactivitate și funcționalități la paginile web.', nchar(13), nchar(10), nchar(13), nchar(10), N'Responsive Design: Abilitatea de a crea pagini web care se adaptează la diferite dimensiuni de ecran (dispozitive desktop, tablete, telefoane mobile).', nchar(13), nchar(10), nchar(13), nchar(10), N'Framework-uri Frontend: Cunoașterea unor cadre de lucru precum React, Angular sau Vue.js pentru dezvoltarea mai eficientă și organizată a interfețelor.', nchar(13), nchar(10), nchar(13), nchar(10), N'Version Control/Git: Înțelegerea sistemelor de control al versiunilor, cum ar fi Git, pentru colaborare și gestionarea eficientă a codului. '), N'Frontend DEVELOPER', CONCAT(CAST(N'Un dezvoltator de frontend este responsabil pentru crearea și implementarea componentelor vizuale ale unei aplicații web sau mobile.Pentru a deveni un dezvoltator de frontend, trebuie să înveți următoarele:' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10)), N'Writing and communication,UI/UX Design Skills, Problem-solving skills, Gândire analitică, Javascript, CSS, HTML, Framework'),
(4, CONCAT(CAST(N'Analizezi datele folosind statistici și matematică.' AS nvarchar(max)), nchar(13), nchar(10), N'Programezi, în special în limbaje precum Python sau R.', nchar(13), nchar(10), N'Lucrezi cu baze de date și cunoști limbajul SQL.', nchar(13), nchar(10), N'Creezi vizualizări pentru a prezenta rezultatele.', nchar(13), nchar(10), N'Folosești instrumente precum Excel, Pandas, NumPy pentru analiză.', nchar(13), nchar(10), N'Înțelegi conceptele statistice de bază.'), N'Data Analyst', CONCAT(CAST(N'În mod succint, un analist de date colectează, analizează și interpretează date pentru a oferi informații valoroase în procesul decizional al unei organizații. Pentru a deveni un astfel de profesionist, trebuie să înveți să:' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10)), N'Writing and communication, Statistical knowledge, Problem-solving skills, Creating dashboards and reports');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_category_job', N'atributii_job', N'denumire_categorie_job', N'descriere_job', N'quality') AND [object_id] = OBJECT_ID(N'[Category_Jobs]'))
    SET IDENTITY_INSERT [Category_Jobs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_job_quality', N'Category_Jobsid_category_job', N'id_category_job', N'quality') AND [object_id] = OBJECT_ID(N'[Job_qualities]'))
    SET IDENTITY_INSERT [Job_qualities] ON;
INSERT INTO [Job_qualities] ([id_job_quality], [Category_Jobsid_category_job], [id_category_job], [quality])
VALUES (12, NULL, 2, N'Familiarity with Servers'),
(45, NULL, 4, N'Creating dashboards and reports'),
(35, NULL, 4, N'Problem-solving skills'),
(25, NULL, 4, N'Statistical knowledge'),
(15, NULL, 4, N'Writing and communication'),
(47, NULL, 3, N'JavaScript'),
(33, NULL, 3, N'Frameworks and Libraries'),
(23, NULL, 3, N'CSS'),
(13, NULL, 3, N'HTML'),
(43, NULL, 2, N'Knowledge of APIs'),
(32, NULL, 2, N'Problem-solving skills'),
(22, NULL, 2, N'Team player'),
(4, NULL, 1, N'Organizat'),
(3, NULL, 1, N'Problem-solving skills'),
(42, NULL, 2, N'Organizat'),
(1, NULL, 1, N'Gândire analitică'),
(2, NULL, 1, N'Team player');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_job_quality', N'Category_Jobsid_category_job', N'id_category_job', N'quality') AND [object_id] = OBJECT_ID(N'[Job_qualities]'))
    SET IDENTITY_INSERT [Job_qualities] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_materie', N'Studentiid_student', N'denumire_materie', N'id_student') AND [object_id] = OBJECT_ID(N'[Materii]'))
    SET IDENTITY_INSERT [Materii] ON;
INSERT INTO [Materii] ([id_materie], [Studentiid_student], [denumire_materie], [id_student])
VALUES (11, NULL, N'Programare orientata obiect - Java', 5),
(10, NULL, N'Dezvoltarea aplicatiilor Web', 5),
(9, NULL, N'Sisteme de gestiune a bazelor de date', 5),
(8, NULL, N'Psihologie politica', 1),
(6, NULL, N'Psihologie politica', 3),
(5, NULL, N'Psihologie sociala', 4),
(4, NULL, N'Tehnici promotionale', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_materie', N'Studentiid_student', N'denumire_materie', N'id_student') AND [object_id] = OBJECT_ID(N'[Materii]'))
    SET IDENTITY_INSERT [Materii] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_materie', N'Studentiid_student', N'denumire_materie', N'id_student') AND [object_id] = OBJECT_ID(N'[Materii]'))
    SET IDENTITY_INSERT [Materii] ON;
INSERT INTO [Materii] ([id_materie], [Studentiid_student], [denumire_materie], [id_student])
VALUES (3, NULL, N'Bazele administratiei publice', 3),
(2, NULL, N'Psihologie politica', 2),
(1, NULL, N'Statistica economica', 1),
(7, NULL, N'Psihologie politica', 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_materie', N'Studentiid_student', N'denumire_materie', N'id_student') AND [object_id] = OBJECT_ID(N'[Materii]'))
    SET IDENTITY_INSERT [Materii] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_orar', N'Materiiid_materie', N'Time_end', N'Time_start', N'id_materie', N'ziua') AND [object_id] = OBJECT_ID(N'[Orar]'))
    SET IDENTITY_INSERT [Orar] ON;
INSERT INTO [Orar] ([id_orar], [Materiiid_materie], [Time_end], [Time_start], [id_materie], [ziua])
VALUES (3, NULL, N'13:50', N'12:00', 1, 0),
(5, NULL, N'17:50', N'16:00', 1, 0),
(4, NULL, N'15:50', N'14:00', 1, 0),
(2, NULL, N'11:50', N'10:00', 1, 0),
(1, NULL, N'09:50', N'08:00', 1, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_orar', N'Materiiid_materie', N'Time_end', N'Time_start', N'id_materie', N'ziua') AND [object_id] = OBJECT_ID(N'[Orar]'))
    SET IDENTITY_INSERT [Orar] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_profesor', N'Materiiid_materie', N'Utilizatoriid_utilizator', N'grad', N'id_materie', N'id_utilizator', N'salariu') AND [object_id] = OBJECT_ID(N'[Profesori]'))
    SET IDENTITY_INSERT [Profesori] ON;
INSERT INTO [Profesori] ([id_profesor], [Materiiid_materie], [Utilizatoriid_utilizator], [grad], [id_materie], [id_utilizator], [salariu])
VALUES (2, NULL, NULL, 1, 2, 4, 5800.0),
(1, NULL, NULL, 0, 1, 3, 5000.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_profesor', N'Materiiid_materie', N'Utilizatoriid_utilizator', N'grad', N'id_materie', N'id_utilizator', N'salariu') AND [object_id] = OBJECT_ID(N'[Profesori]'))
    SET IDENTITY_INSERT [Profesori] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_Specializare', N'denumire_specializare') AND [object_id] = OBJECT_ID(N'[Specializari]'))
    SET IDENTITY_INSERT [Specializari] ON;
INSERT INTO [Specializari] ([id_Specializare], [denumire_specializare])
VALUES (6, N'Computer science'),
(5, N'Asistenta sociala'),
(4, N'Marketing'),
(3, N'Drept administrativ'),
(2, N'Stiinte politice'),
(1, N'Finante');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_Specializare', N'denumire_specializare') AND [object_id] = OBJECT_ID(N'[Specializari]'))
    SET IDENTITY_INSERT [Specializari] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_student', N'Specializariid_Specializare', N'Utilizatoriid_utilizator', N'id_specializare', N'id_utilizator', N'scutit_plata') AND [object_id] = OBJECT_ID(N'[Studenti]'))
    SET IDENTITY_INSERT [Studenti] ON;
INSERT INTO [Studenti] ([id_student], [Specializariid_Specializare], [Utilizatoriid_utilizator], [id_specializare], [id_utilizator], [scutit_plata])
VALUES (3, NULL, NULL, 3, 6, CAST(0 AS bit)),
(2, NULL, NULL, 2, 2, CAST(0 AS bit)),
(5, NULL, NULL, 6, 8, CAST(1 AS bit)),
(4, NULL, NULL, 4, 7, CAST(1 AS bit)),
(1, NULL, NULL, 1, 1, CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_student', N'Specializariid_Specializare', N'Utilizatoriid_utilizator', N'id_specializare', N'id_utilizator', N'scutit_plata') AND [object_id] = OBJECT_ID(N'[Studenti]'))
    SET IDENTITY_INSERT [Studenti] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_utilizator', N'email', N'nume', N'parola', N'prenume', N'username') AND [object_id] = OBJECT_ID(N'[Utilizatori]'))
    SET IDENTITY_INSERT [Utilizatori] ON;
INSERT INTO [Utilizatori] ([id_utilizator], [email], [nume], [parola], [prenume], [username])
VALUES (7, N'pop_ana1999@yahoo.com', N'Pop', N'pop1112', N'Ana', N'PopAna'),
(6, N'ionescu_denis@gmail.com', N'Ionescu', N'boboc12345', N'Denis', N'IonescuDenis'),
(5, N'anastasia_sia@yahoo.ro', N'Soare', N'sia73737*', N'Anastasia', N'AnastasiaS'),
(4, N'flo_andrei@yahoo.com', N'Florescu', N'moviehsjjs', N'Andrei', N'FlorescuAndrei'),
(3, N'george_07@gmail.com', N'Ciobanu', N'dogiuaaj922', N'George', N'George0647'),
(2, N'ana_maria@yahoo.com', N'Ion', N'ana827272', N'Ana-Maria', N'AnaMaria'),
(1, N'matei_matt@yahoo.ro', N'Solomon', N'matte777*', N'Matei', N'MateiSolomon'),
(8, N'toma_mihai@yahoo.com', N'Toma', N'tom1112$', N'Mihai', N'TomaMihai');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_utilizator', N'email', N'nume', N'parola', N'prenume', N'username') AND [object_id] = OBJECT_ID(N'[Utilizatori]'))
    SET IDENTITY_INSERT [Utilizatori] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_subject_category', N'Category_Jobsid_category_job', N'Materiiid_materie', N'id_category_job', N'id_materie') AND [object_id] = OBJECT_ID(N'[subject_category]'))
    SET IDENTITY_INSERT [subject_category] ON;
INSERT INTO [subject_category] ([id_subject_category], [Category_Jobsid_category_job], [Materiiid_materie], [id_category_job], [id_materie])
VALUES (4, NULL, NULL, 1, 11),
(1, NULL, NULL, 4, 9),
(2, NULL, NULL, 2, 9),
(3, NULL, NULL, 3, 10),
(5, NULL, NULL, 2, 10);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_subject_category', N'Category_Jobsid_category_job', N'Materiiid_materie', N'id_category_job', N'id_materie') AND [object_id] = OBJECT_ID(N'[subject_category]'))
    SET IDENTITY_INSERT [subject_category] OFF;
GO

CREATE INDEX [IX_Administratori_Utilizatoriid_utilizator] ON [Administratori] ([Utilizatoriid_utilizator]);
GO

CREATE INDEX [IX_Calificative_Materiiid_materie] ON [Calificative] ([Materiiid_materie]);
GO

CREATE INDEX [IX_Calificative_Studentiid_student] ON [Calificative] ([Studentiid_student]);
GO

CREATE INDEX [IX_Job_qualities_Category_Jobsid_category_job] ON [Job_qualities] ([Category_Jobsid_category_job]);
GO

CREATE INDEX [IX_Jobs_Category_Jobsid_category_job] ON [Jobs] ([Category_Jobsid_category_job]);
GO

CREATE INDEX [IX_Materii_Studentiid_student] ON [Materii] ([Studentiid_student]);
GO

CREATE INDEX [IX_Orar_Materiiid_materie] ON [Orar] ([Materiiid_materie]);
GO

CREATE INDEX [IX_Profesori_Materiiid_materie] ON [Profesori] ([Materiiid_materie]);
GO

CREATE INDEX [IX_Profesori_Utilizatoriid_utilizator] ON [Profesori] ([Utilizatoriid_utilizator]);
GO

CREATE INDEX [IX_Studenti_Specializariid_Specializare] ON [Studenti] ([Specializariid_Specializare]);
GO

CREATE INDEX [IX_Studenti_Utilizatoriid_utilizator] ON [Studenti] ([Utilizatoriid_utilizator]);
GO

CREATE INDEX [IX_subject_category_Category_Jobsid_category_job] ON [subject_category] ([Category_Jobsid_category_job]);
GO

CREATE INDEX [IX_subject_category_Materiiid_materie] ON [subject_category] ([Materiiid_materie]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231203181209_InitialCreate', N'5.0.17');
GO

COMMIT;
GO

