using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<PagedList<TblCurso>> GetAllCurso(int pageNumber, int pageSize);
        Task<TblCurso> GetCursoById(int id);
        Task<PagedList<TblCurso>> GetCursoByFiltroAsync(string categoria, int pageNumber, int pageSize);
        Task<PagedList<TblCurso>> GetCursoByTermoAsync(string termo, int pageNumber, int pageSize);
        Task<TblCurso> PostCurso(TblCurso curso);
        Task<TblCurso> PutCurso(TblCurso curso);
        Task<TblCurso> DeleteCursoById(int id);
    }
}
