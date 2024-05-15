using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlataformaCursos.API.Errors;
using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Domain.Pagination;
using PlataformaCursos.Infrastructure.Data.Context;
using PlataformaCursos.Infrastructure.Data.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PlataformaCursos.Infrastructure.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;
        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<TblCurso>> GetAllCurso(int pageNumber, int pageSize)
        {
            var query = _context.Curso.Where(x => x.Ativo == true).OrderBy(x => x.Id).AsQueryable();
            var cursos = await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
            return cursos;
        }

        public async Task<TblCurso> GetCursoById(int id)
        {
            var curso = await _context.Curso.Where(x => x.Ativo == true).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return curso!;
        }
        public async Task<PagedList<TblCurso>> GetCursoByFiltroAsync(string categoria, int pageNumber, int pageSize)
        {

            var query = from curso in _context.Curso
                        join cursoCategoria in _context.CursoCategoria
                        on curso.Id equals cursoCategoria.CursoId
                        join categori in _context.Categoria
                        on cursoCategoria.CategoriaId equals categori.Id
                        where categori.Nome == categoria && curso.Ativo == true
                        select curso;

            if (query.IsNullOrEmpty())
            {
                 query = _context.Curso.Where(x => x.Ativo == true).OrderBy(x => x.Id).AsQueryable();
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedList<TblCurso>> GetCursoByTermoAsync(string termo, int pageNumber, int pageSize)
        {

            var query = from curso in _context.Curso.Distinct() orderby curso.Id
                        where (curso.Titulo.Contains(termo) || curso.Descricao.Contains(termo)) && curso.Ativo == true
                        select curso;

            if (query.IsNullOrEmpty())
            {
                query = _context.Curso.Where(x => x.Ativo == true).OrderBy(x => x.Id).AsQueryable();
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<TblCurso> PostCurso(TblCurso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<TblCurso> PutCurso(TblCurso curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<TblCurso> DeleteCursoById(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso != null)
            {
                curso.Excluir();
                _context.Curso.Update(curso);
                await _context.SaveChangesAsync();
                return curso;
            }

            return null!;
        }

    }
}
