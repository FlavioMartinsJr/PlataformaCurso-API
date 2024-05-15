using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{ 
    public class CategoriaConfiguration : IEntityTypeConfiguration<TblCategoria>
    {
        public void Configure(EntityTypeBuilder<TblCategoria> builder)
        {
            builder.ToTable("Tbl_categoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasMaxLength(255).IsUnicode(false).HasColumnName("nome");
        }
    }
}
