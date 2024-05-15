using Microsoft.EntityFrameworkCore;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Infrastructure.Data.Context;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;
        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TblMatricula> DeleteMatriculaById(int id)
        {
            var query = await _context.Matricula.FindAsync(id);

            if (query != null)
            {
                var tabelaDependente = from matricula in _context.Matricula
                                       join matriculaCapitulo in _context.MatriculaCapitulo
                                       on matricula.Id equals matriculaCapitulo.MatriculaId
                                       join curso in _context.Curso
                                       on matricula.CursoId equals curso.Id
                                       where curso.Ativo == true && matriculaCapitulo.MatriculaId == id
                                       select matriculaCapitulo;

                if (tabelaDependente.Count() > 0)
                {
                    _context.MatriculaCapitulo.RemoveRange(tabelaDependente);
                    await _context.SaveChangesAsync();
                }

                _context.Matricula.Remove(query);
                await _context.SaveChangesAsync();
            }
            return query!;
        }

        public async Task<IEnumerable<TblMatricula>> GetAllMatricula(int usuarioId)
        {
            var query = from matricula in _context.Matricula
                        join curso in _context.Curso
                        on matricula.CursoId equals curso.Id
                        where curso.Ativo == true && matricula.UsuarioId == usuarioId
                        select matricula;

            return await query.ToListAsync();
        }

        public async Task<TblMatricula> GetMatriculaById(int id)
        {
            var query = await _context.Matricula.FindAsync(id);
            return query!;
        }

        public async Task<TblMatricula> PostMatricula(TblMatricula matricula)
        {
            var queryUser = await _context.Usuario.FindAsync(matricula.UsuarioId);
            var queryCurso = await _context.Curso.FindAsync(matricula.CursoId);

            if (queryUser != null && queryCurso != null)
            {
                _context.Matricula.Add(matricula);
                await _context.SaveChangesAsync();
                return matricula!;
            }
            return null!;
        }

    }
}
