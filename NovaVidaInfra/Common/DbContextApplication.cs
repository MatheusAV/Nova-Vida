using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovaVidaDomain.Models;
using NovaVidaInfra.Maps;

namespace NovaVidaInfra.Common
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication() { }
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("App");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
            modelBuilder.Entity<Professor>(new ProfessorMap().Configure);           
        }
    }
}
