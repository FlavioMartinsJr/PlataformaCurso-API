using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Infrastructure.Data.Context;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class CapituloRepository : ICapituloRepository
    {
        private readonly ApplicationDbContext _context;

        public CapituloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TblCapitulo> DeleteCapituloById(int id)
        {
            var query = await _context.Capitulo.FindAsync(id);

            if (query != null)
            {
                var tabelaDependente = from capitulo in _context.Capitulo
                                       join matriculaCapitulo in _context.MatriculaCapitulo
                                       on capitulo.Id equals matriculaCapitulo.CapituloId
                                       join curso in _context.Curso
                                       on capitulo.CursoId equals curso.Id
                                       where curso.Ativo == true && matriculaCapitulo.CapituloId == id
                                       select matriculaCapitulo;
                
                if(tabelaDependente.Count() > 0)
                {
                    _context.MatriculaCapitulo.RemoveRange(tabelaDependente);
                    await _context.SaveChangesAsync();
                }

                _context.Capitulo.Remove(query);
                await _context.SaveChangesAsync();
            }
            return query!;
        }

        public async Task<IEnumerable<TblCapitulo>> GetAllCapitulo(int cursoId)
        {
            var query = from capitulo in _context.Capitulo
                        join curso in _context.Curso
                        on capitulo.CursoId equals curso.Id
                        where curso.Ativo == true && capitulo.CursoId == cursoId
                        select capitulo;

            return await query.ToListAsync();
        }

        public async Task<TblCapitulo> GetCapituloById(int id)
        {
            var query = await _context.Capitulo.FindAsync(id);
            return query!;
        }

        public async Task<TblCapitulo> PostCapitulo(TblCapitulo capitulo)
        {
            var query = await _context.Curso.FindAsync(capitulo.CursoId);

            if (query != null)
            {
                _context.Capitulo.Add(capitulo);
                await _context.SaveChangesAsync();
                return capitulo!;
            }
            return null!;
        }

        public async Task<TblCapitulo> PutCapitulo(TblCapitulo capitulo)
        {
            var query = await _context.Capitulo.FindAsync(capitulo.Id);

            if (query != null)
            {
                query.Titulo = capitulo.Titulo;
                query.Descricao = capitulo.Descricao;
                query.VideoUrl = capitulo.VideoUrl != null? capitulo.VideoUrl : query.VideoUrl;
                query.DataAlteracao = capitulo.DataAlteracao;
                await _context.SaveChangesAsync();
            }
            return query!;
        }
    }
}
