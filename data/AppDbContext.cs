using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AtividadeModel> Atividades { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        // initialize the Status table with some default values
        // Você pode ou não sobrescrever uma função virtual 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusModel>().HasData(
                new StatusModel { Id = 1, Nome = "Pendente" },
                new StatusModel { Id = 2, Nome = "Em andamento" },
                new StatusModel { Id = 3, Nome = "Pendente" }
            );
        }

    }
}