using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Status> Status { get; set; }

        // initialize the Status table with some default values
        // Você pode ou não sobrescrever uma função virtual 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Nome = "Pendente" },
                new Status { Id = 2, Nome = "Em andamento" },
                new Status { Id = 3, Nome = "Pendente" }
            );
        }

    }
}