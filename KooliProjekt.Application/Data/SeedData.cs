using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;


namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {


        public static void Generate(ApplicationDbContext context)
        {

            if (context.Customers.Any())
            {
                return;
            }
            SeedCustomers(context);
            SeedProjects(context);
            SeedTasks(context);
            SeedWorklogs(context);
        }




        private static void SeedCustomers(ApplicationDbContext context)
        {

            var customers = new List<Customer>()
            {

                new Customer { CustomerName = "AlarKaris", PasswordHash = "hash12345" },
                new Customer { CustomerName = "AllarJüri", PasswordHash = "hash67890" },
                new Customer { CustomerName = "MariTamm", PasswordHash = "hash24680" },
                new Customer { CustomerName = "JaanTamm", PasswordHash = "hash13579" },
                new Customer { CustomerName = "KatiKask", PasswordHash = "hash98765" },
                new Customer { CustomerName = "MartinSaar", PasswordHash = "hash54321" },
                new Customer { CustomerName = "LiisPärn", PasswordHash = "hash11223" },
                new Customer { CustomerName = "KarlMets", PasswordHash = "hash44556" },
                new Customer { CustomerName = "AnnaSepp", PasswordHash = "hash77889" },
                new Customer { CustomerName = "PeeterKukk", PasswordHash = "hash99887" },
                new Customer { CustomerName = "LauraIlves", PasswordHash = "hash66778" },
                new Customer { CustomerName = "RasmusRebane", PasswordHash = "hash33445" },
                new Customer { CustomerName = "HelenOja", PasswordHash = "hash55667" },
                new Customer { CustomerName = "MarkoPõder", PasswordHash = "hash88990" },
                new Customer { CustomerName = "EleriKuusk", PasswordHash = "hash22334" },
                new Customer { CustomerName = "AndresLepp", PasswordHash = "hash77881" },
                new Customer { CustomerName = "KristiMägi", PasswordHash = "hash99112" },
                new Customer { CustomerName = "SiimVaher", PasswordHash = "hash44332" },
                new Customer { CustomerName = "GreteAas", PasswordHash = "hash66554" },
                new Customer { CustomerName = "TaaviLill", PasswordHash = "hash88776" },
                new Customer { CustomerName = "PiretKivi", PasswordHash = "hash11998" },
                new Customer { CustomerName = "MartenHallik", PasswordHash = "hash22446" },
                new Customer { CustomerName = "EevaRand", PasswordHash = "hash33557" },
                new Customer { CustomerName = "TanelAru", PasswordHash = "hash44668" },
                new Customer { CustomerName = "SanderKaru", PasswordHash = "hash55779" },
                new Customer { CustomerName = "MerleSild", PasswordHash = "hash66880" },
                new Customer { CustomerName = "RobinPaju", PasswordHash = "hash77991" },
                new Customer { CustomerName = "KadriTeder", PasswordHash = "hash88002" },
                new Customer { CustomerName = "HenriKoppel", PasswordHash = "hash10112" },
                new Customer { CustomerName = "BirgitSalu", PasswordHash = "hash20223" },
                new Customer { CustomerName = "ErikPõld", PasswordHash = "hash30334" },
                new Customer { CustomerName = "SandraKoit", PasswordHash = "hash40445" },
                new Customer { CustomerName = "MihkelNurme", PasswordHash = "hash50556" },
                new Customer { CustomerName = "AnuKalda", PasswordHash = "hash60667" },
                new Customer { CustomerName = "RaulAas", PasswordHash = "hash70778" }

            };
            context.Customers.AddRange(customers);
            context.SaveChanges();


        }


        private static void SeedProjects(ApplicationDbContext context)
        {
            var projects = new List<Projekt>()
            {
                    new Projekt { Name = "Veebilehe arendus", CustomerId = 1 },
                    new Projekt { Name = "Mobiilirakendus", CustomerId = 2 },
                    new Projekt { Name = "Andmebaasi loomine", CustomerId = 3 },
                    new Projekt { Name = "Kodulehe uuendus", CustomerId = 4 },
                    new Projekt { Name = "E-poe arendus", CustomerId = 5 },
                    new Projekt { Name = "Kooli infosüsteem", CustomerId = 6 },
                    new Projekt { Name = "Projektihaldus", CustomerId = 7 },
                    new Projekt { Name = "Raamatukogu süsteem", CustomerId = 8 },
                    new Projekt { Name = "Õpilaste register", CustomerId = 9 },
                    new Projekt { Name = "Laohaldus", CustomerId = 10 },
          
                new Projekt { Name = "Müügisüsteem", CustomerId = 11 },
                    new Projekt { Name = "Personalihaldus", CustomerId = 12 },
                    new Projekt { Name = "Arvete süsteem", CustomerId = 13 },
                    new Projekt { Name = "Broneerimisrakendus", CustomerId = 14 },
                    new Projekt { Name = "Tööaja arvestus", CustomerId = 15 },
                    new Projekt { Name = "Kliendiportaal", CustomerId = 16 },
                    new Projekt { Name = "Maksekeskkond", CustomerId = 17 },
                    new Projekt { Name = "Uudisteportaal", CustomerId = 18 },
                    new Projekt { Name = "Spordiklubi süsteem", CustomerId = 19 },
                    new Projekt { Name = "Restorani veebileht", CustomerId = 20 },
                    new Projekt { Name = "Reklaamikampaania", CustomerId = 21 },
                    new Projekt { Name = "Andmete analüüs", CustomerId = 22 },
                    new Projekt { Name = "Turunduse rakendus", CustomerId = 23 },
                    new Projekt { Name = "Dokumendihaldus", CustomerId = 24 },
                    new Projekt { Name = "Laenutussüsteem", CustomerId = 25 },
                    new Projekt { Name = "Õppekeskkond", CustomerId = 26 },
                    new Projekt { Name = "Ürituste kalender", CustomerId = 27 },
                    new Projekt { Name = "Töötajate register", CustomerId = 28 },
                    new Projekt { Name = "Tellimuste haldus", CustomerId = 29 },
                    new Projekt { Name = "Finantsarvestus", CustomerId = 30 },
                    new Projekt { Name = "Klienditeenindus", CustomerId = 31 },
                    new Projekt { Name = "Mobiilimäng", CustomerId = 32 },
                    new Projekt { Name = "Veebipood", CustomerId = 33 },
                    new Projekt { Name = "Tööülesannete haldus", CustomerId = 34 },
                    new Projekt { Name = "Ettevõtte infosüsteem", CustomerId = 35 }

            };
            context.Projekts.AddRange(projects);
            context.SaveChanges();
        }

        private static void SeedTasks(ApplicationDbContext context)
        {
            var tasks = new List<Task>()
            {

                new Task { Title = "Kujunduse loomine", Worker = "Jaan Tamme" },
                new Task { Title = "Andmebaasi seadistamine", Worker = "Vidrik Eler" },
                new Task { Title = "Veebilehe arendus", Worker = "Mari Tamm" },
                new Task { Title = "Rakenduse testimine", Worker = "Karl Mets" },
                new Task { Title = "Dokumentatsiooni koostamine", Worker = "Anna Sepp" },
                new Task { Title = "Kasutajaliidese loomine", Worker = "Martin Saar" },
                new Task { Title = "Sisselogimise arendus", Worker = "Liis Pärn" },
                new Task { Title = "Andmete sisestamine", Worker = "Peeter Kukk" },
                new Task { Title = "Vigade parandamine", Worker = "Laura Ilves" },
                new Task { Title = "API loomine", Worker = "Rasmus Rebane" },
                new Task { Title = "Andmebaasi testimine", Worker = "Helen Oja" },
                new Task { Title = "Avalehe kujundamine", Worker = "Marko Põder" },
                new Task { Title = "Turvalisuse kontroll", Worker = "Eleri Kuusk" },
                new Task { Title = "Koodi ülevaatus", Worker = "Andres Lepp" },
                new Task { Title = "Raportite loomine", Worker = "Kristi Mägi" },
                new Task { Title = "Projektiplaani koostamine", Worker = "Siim Vaher" },
                new Task { Title = "Piltide lisamine", Worker = "Grete Aas" },
                new Task { Title = "Menüü arendamine", Worker = "Taavi Lill" },
                new Task { Title = "Otsingufunktsiooni loomine", Worker = "Piret Kivi" },
                new Task { Title = "Kasutajate haldus", Worker = "Marten Hallik" },
                new Task { Title = "Vormide valideerimine", Worker = "Eeva Rand" },
                new Task { Title = "Lehe kiiruse parandamine", Worker = "Tanel Aru" },
                new Task { Title = "Mobiilivaate loomine", Worker = "Sander Karu" },
                new Task { Title = "Andmete eksportimine", Worker = "Merle Sild" },
                new Task { Title = "Failide üleslaadimine", Worker = "Robin Paju" },
                new Task { Title = "Kasutajate registreerimine", Worker = "Kadri Teder" },
                new Task { Title = "Teavituste süsteem", Worker = "Henri Koppel" },
                new Task { Title = "Arvete genereerimine", Worker = "Birgit Salu" },
                new Task { Title = "Tellimuste haldus", Worker = "Erik Põld" },
                new Task { Title = "Veebilehe uuendamine", Worker = "Sandra Koit" },
                new Task { Title = "Süsteemi dokumenteerimine", Worker = "Mihkel Nurme" },
                new Task { Title = "Kujunduse parandamine", Worker = "Anu Kalda" },
                new Task { Title = "Andmete kontrollimine", Worker = "Raul Aas" },
                new Task { Title = "Funktsioonide lisamine", Worker = "Jaan Tamme" },
                new Task { Title = "Lõplik testimine", Worker = "Vidrik Eler" }
            };
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
        }
        private static void SeedWorklogs(ApplicationDbContext context)
        {

            var Worklogs = new List<WorkLog>()
            {
            new WorkLog { Date = DateTime.Now, Worker = "Jaan Tamme", TaskId = 1 },
            new WorkLog { Date = DateTime.Now.AddDays(-1), Worker = "Vidrik Eler", TaskId = 2 },
            new WorkLog { Date = DateTime.Now.AddDays(-2), Worker = "Mari Tamm", TaskId = 3 },
            new WorkLog { Date = DateTime.Now.AddDays(-3), Worker = "Karl Mets", TaskId = 4 },
            new WorkLog { Date = DateTime.Now.AddDays(-4), Worker = "Anna Sepp", TaskId = 5 },
            new WorkLog { Date = DateTime.Now.AddDays(-5), Worker = "Martin Saar", TaskId = 6 },
            new WorkLog { Date = DateTime.Now.AddDays(-6), Worker = "Liis Pärn", TaskId = 7 },
            new WorkLog { Date = DateTime.Now.AddDays(-7), Worker = "Peeter Kukk", TaskId = 8 },
            new WorkLog { Date = DateTime.Now.AddDays(-8), Worker = "Laura Ilves", TaskId = 9 },
            new WorkLog { Date = DateTime.Now.AddDays(-9), Worker = "Rasmus Rebane", TaskId = 10 },
            new WorkLog { Date = DateTime.Now.AddDays(-10), Worker = "Helen Oja", TaskId = 11 },
            new WorkLog { Date = DateTime.Now.AddDays(-11), Worker = "Marko Põder", TaskId = 12 },
            new WorkLog { Date = DateTime.Now.AddDays(-12), Worker = "Eleri Kuusk", TaskId = 13 },
            new WorkLog { Date = DateTime.Now.AddDays(-13), Worker = "Andres Lepp", TaskId = 14 },
            new WorkLog { Date = DateTime.Now.AddDays(-14), Worker = "Kristi Mägi", TaskId = 15 },
            new WorkLog { Date = DateTime.Now.AddDays(-15), Worker = "Siim Vaher", TaskId = 16 },
            new WorkLog { Date = DateTime.Now.AddDays(-16), Worker = "Grete Aas", TaskId = 17 },
            new WorkLog { Date = DateTime.Now.AddDays(-17), Worker = "Taavi Lill", TaskId = 18 },
            new WorkLog { Date = DateTime.Now.AddDays(-18), Worker = "Piret Kivi", TaskId = 19 },
            new WorkLog { Date = DateTime.Now.AddDays(-19), Worker = "Marten Hallik", TaskId = 20 },
            new WorkLog { Date = DateTime.Now.AddDays(-20), Worker = "Eeva Rand", TaskId = 21 },
            new WorkLog { Date = DateTime.Now.AddDays(-21), Worker = "Tanel Aru", TaskId = 22 },
            new WorkLog { Date = DateTime.Now.AddDays(-22), Worker = "Sander Karu", TaskId = 23 },
            new WorkLog { Date = DateTime.Now.AddDays(-23), Worker = "Merle Sild", TaskId = 24 },
            new WorkLog { Date = DateTime.Now.AddDays(-24), Worker = "Robin Paju", TaskId = 25 },
            new WorkLog { Date = DateTime.Now.AddDays(-25), Worker = "Kadri Teder", TaskId = 26 },
            new WorkLog { Date = DateTime.Now.AddDays(-26), Worker = "Henri Koppel", TaskId = 27 },
            new WorkLog { Date = DateTime.Now.AddDays(-27), Worker = "Birgit Salu", TaskId = 28 },
            new WorkLog { Date = DateTime.Now.AddDays(-28), Worker = "Erik Põld", TaskId = 29 },
            new WorkLog { Date = DateTime.Now.AddDays(-29), Worker = "Sandra Koit", TaskId = 30 },
            new WorkLog { Date = DateTime.Now.AddDays(-30), Worker = "Mihkel Nurme", TaskId = 31 },
            new WorkLog { Date = DateTime.Now.AddDays(-31), Worker = "Anu Kalda", TaskId = 32 },
            new WorkLog { Date = DateTime.Now.AddDays(-32), Worker = "Raul Aas", TaskId = 33 },
            new WorkLog { Date = DateTime.Now.AddDays(-33), Worker = "Jaan Tamme", TaskId = 34 },
            new WorkLog { Date = DateTime.Now.AddDays(-34), Worker = "Vidrik Eler", TaskId = 35 }


                };
            context.WorkLogs.AddRange(Worklogs);
            context.SaveChanges();
                        
        }
    }
}
