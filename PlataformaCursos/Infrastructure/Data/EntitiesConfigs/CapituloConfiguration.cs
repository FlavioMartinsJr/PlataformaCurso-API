using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class CapituloConfiguration : IEntityTypeConfiguration<TblCapitulo>
    {
        public void Configure(EntityTypeBuilder<TblCapitulo> builder)
        {
            builder.ToTable("Tbl_capitulo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CursoId).HasColumnName("cursoId").IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(255).IsUnicode(false).HasColumnName("descricao");
            builder.Property(x => x.Titulo).HasMaxLength(255).IsUnicode(false).HasColumnName("titulo");
            builder.Property(x => x.VideoUrl).HasMaxLength(255).IsUnicode(false).HasColumnName("videoUrl");
            builder.Property(x => x.DataAlteracao).HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasColumnName("dataCriacao");
            builder.HasOne(x => x.Curso).WithMany(c => c.Capitulo).HasForeignKey(v => v.CursoId);
        }
    }
}
