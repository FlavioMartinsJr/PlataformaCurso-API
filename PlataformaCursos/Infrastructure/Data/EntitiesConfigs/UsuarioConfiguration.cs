using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.EntitiesConfigs
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<TblUsuario>
    {
        public void Configure(EntityTypeBuilder<TblUsuario> builder)
        {
            builder.ToTable("Tbl_usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IsProfessor).HasDefaultValue(false).HasColumnName("isProfessor");
            builder.Property(x => x.IsAdmin).IsRequired();
            builder.Property(x => x.Ativo).HasDefaultValue(true).HasColumnName("ativo");
            builder.Property(x => x.Email).HasMaxLength(255).IsUnicode(false).HasColumnName("email");
            builder.Property(x => x.DataAlteracao).HasColumnType("datetime").HasColumnName("dataAlteracao");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasColumnName("dataCriacao");
        }
    }
}
