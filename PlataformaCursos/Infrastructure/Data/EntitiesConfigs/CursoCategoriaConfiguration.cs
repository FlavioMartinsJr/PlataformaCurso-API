using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class CursoCategoriaConfiguration : IEntityTypeConfiguration<TblCursoCategoria>
    {
        public void Configure(EntityTypeBuilder<TblCursoCategoria> builder)
        {
            builder.ToTable("Tbl_cursoCategoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CategoriaId).HasColumnName("categoriaId").IsRequired();
            builder.Property(x => x.CursoId).HasColumnName("cursoId").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(c => c.CursoCategoria).HasForeignKey(v => v.CategoriaId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Curso).WithMany(c => c.CursoCategoria).HasForeignKey(v => v.CursoId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
