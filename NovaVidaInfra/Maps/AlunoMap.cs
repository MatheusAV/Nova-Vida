using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaVidaDomain.Models;

public class AlunoMap : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Alunos"); // Tabela

        builder.HasKey(e => e.AlunoId);

        builder.Property(e => e.Nome) .IsRequired().HasMaxLength(100).HasColumnName("Nome");

        builder.Property(e => e.ValorMensalidade) .HasColumnType("decimal(18, 2)").HasColumnName("ValorMensalidade");   

        builder.Property(e => e.DataVencimento).HasColumnType("date").HasColumnName("DataVencimento");

        builder.Property(e => e.IdProfessor).HasColumnName("IdProfessor");       
    }
}