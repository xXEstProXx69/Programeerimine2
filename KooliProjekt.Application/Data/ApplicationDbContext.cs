using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Projekt> Projekts { get; set; } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
    }
}
