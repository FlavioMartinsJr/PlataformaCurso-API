using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class AnexoConfiguration : IEntityTypeConfiguration<TblAnexo>
    {
        public void Configure(EntityTypeBuilder<TblAnexo> builder)
        {
            builder.ToTable("Tbl_anexo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CursoId).HasColumnName("cursoId").IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(255).IsUnicode(false).HasColumnName("nome");
            builder.Property(x => x.ArquivoUrl).HasMaxLength(255).IsUnicode(false).HasColumnName("arquivoUrl");
            builder.Property(x => x.DataAlteracao).HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasColumnName("dataCriacao");
            builder.HasOne(d => d.Curso).WithMany(c => c.Anexo).HasForeignKey(v => v.CursoId);
        }
    }
}
