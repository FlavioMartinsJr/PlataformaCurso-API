using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;

namespace PlataformaCursos.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() : base() { }

        public DbSet<TblCurso> Curso { get; set; }
        public DbSet<TblAnexo> Anexo { get; set; }
        public DbSet<TblCapitulo> Capitulo { get; set; }
        public DbSet<TblCategoria> Categoria { get; set; }
        public DbSet<TblUsuario> Usuario { get; set; }
        public DbSet<TblMatricula> Matricula { get; set; }
        public DbSet<TblMatriculaCapitulo> MatriculaCapitulo { get; set; }
        public DbSet<TblCursoCategoria> CursoCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
