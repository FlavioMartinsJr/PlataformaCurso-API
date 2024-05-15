using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<TblMatricula>
    {
        public void Configure(EntityTypeBuilder<TblMatricula> builder)
        {
            builder.ToTable("Tbl_matricula");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CursoId).HasColumnName("cursoId").IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasColumnName("dataCriacao");
            builder.HasOne(x => x.Curso).WithMany(c => c.Matricula).HasForeignKey(v => v.CursoId);
            builder.HasOne(x => x.Usuario).WithMany(c => c.Matricula).HasForeignKey(v => v.UsuarioId);


        }
    }
}
