using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class CursoConfiguration : IEntityTypeConfiguration<TblCurso>
    {
        public void Configure(EntityTypeBuilder<TblCurso> builder)
        {
            builder.ToTable("Tbl_curso");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Descricao).HasMaxLength(255).IsUnicode(false).HasColumnName("descricao");
            builder.Property(x => x.ImagemUrl).HasMaxLength(255).IsUnicode(false).HasColumnName("imagemUrl");
            builder.Property(x => x.Preco).HasColumnType("decimal(5, 2)").HasColumnName("preco");
            builder.Property(x => x.Publicado).HasDefaultValue(true).HasColumnName("publicado");
            builder.Property(x => x.Ativo).HasDefaultValue(true).HasColumnName("ativo");
            builder.Property(x => x.Titulo).HasMaxLength(255).IsUnicode(false).HasColumnName("titulo");
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasColumnName("dataCriacao");
            builder.HasOne(x => x.Usuario).WithMany(c => c.Curso).HasForeignKey(v => v.UsuarioId);
        }
    }
}
