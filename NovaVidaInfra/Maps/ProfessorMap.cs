using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaVidaDomain.Models;

namespace NovaVidaInfra.Maps
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores"); // Nome da tabela

            builder.HasKey(e => e.ProfessorId);

            builder.Property(e => e.Nome).IsRequired().HasMaxLength(100).HasColumnName("Nome");

            builder.Property(e => e.DataContratacao).HasColumnType("date").HasColumnName("DataContratacao");

            builder.Property(e => e.Departamento).HasMaxLength(100).HasColumnName("Departamento");

            builder.Property(e => e.Materia).HasMaxLength(100).HasColumnName("Materia");
           
        }
    }
}