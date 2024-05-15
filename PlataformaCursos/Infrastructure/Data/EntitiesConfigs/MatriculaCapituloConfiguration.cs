using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class MatriculaCapituloConfiguration : IEntityTypeConfiguration<TblMatriculaCapitulo>
    {
        public void Configure(EntityTypeBuilder<TblMatriculaCapitulo> builder)
        {
            builder.ToTable("Tbl_matriculaCapitulo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CapituloId).HasColumnName("capituloId").IsRequired();
            builder.Property(x => x.MatriculaId).HasColumnName("matriculaId").IsRequired();
            builder.Property(x => x.Completo).HasDefaultValue(true).HasColumnName("completo");
            builder.HasOne(x => x.Capitulo).WithMany(c => c.MatriculaCapitulo).HasForeignKey(v => v.CapituloId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Matricula).WithMany(c => c.MatriculaCapitulo).HasForeignKey(v => v.MatriculaId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
