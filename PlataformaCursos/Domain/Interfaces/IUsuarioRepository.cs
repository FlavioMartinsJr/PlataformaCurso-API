using PlataformaCursos.Domain.Entities;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<PagedList<TblUsuario>> GetAllUsuario(int pageNumber, int pageSize);
        Task<TblUsuario> GetUsuarioById(int id);
        Task<TblUsuario> GetUsuarioByEmail(string email);

        Task<bool> isExistUsuario();
        Task<TblUsuario> PostUsuario(TblUsuario usuario);
        Task<TblUsuario> PutUsuario(TblUsuario usuario);
        Task<TblUsuario> DeleteUsuarioById(int id);
    }
}
