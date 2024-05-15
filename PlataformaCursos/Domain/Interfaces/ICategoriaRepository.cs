using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<TblCategoria>> GetAllCategoria();
        Task<TblCategoria> GetCategoriaById(int id);
        Task<TblCategoria> GetCategoriaByNome(string nome);
        Task<TblCategoria> PostCategoria(TblCategoria categoria);
        Task<TblCategoria> PutCategoria(TblCategoria categoria);
        Task<TblCategoria> DeleteCategoriaById(int id);
    }
}
