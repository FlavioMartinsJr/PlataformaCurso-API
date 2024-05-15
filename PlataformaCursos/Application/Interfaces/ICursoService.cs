using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Application.Interfaces
{
    public interface ICursoService
    {
        Task<PagedList<CursoGet>> BuscaCurso(int pageNumber, int pageSize);
        Task<CursoGet> BuscaCursoPorId(int id);
        Task<PagedList<CursoGet>> BuscaCursoPorFiltro(string categoria, int pageNumber, int pageSize);
        Task<PagedList<CursoGet>> BuscaCursoPorTermo(string termo, int pageNumber, int pageSize);
        Task<CursoPost> AdicionaCurso(CursoPost curso);
        Task<CursoPut> AtualizaCurso(CursoPut curso);
        Task<CursoPut> DeletaCursoPorId(int id);
    }
}
