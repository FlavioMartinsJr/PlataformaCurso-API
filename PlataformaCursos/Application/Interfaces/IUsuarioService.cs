using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.DTOs.Usuario;
using PlataformaCursos.Domain.Pagination;

namespace PlataformaCursos.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<PagedList<UsuarioGet>> BuscaUsuario(int pageNumber, int pageSize);
        Task<UsuarioGet> BuscaUsuarioPorId(int id);
        Task<UsuarioGet> BuscaUsuarioPorEmail(string email);
        Task<UsuarioPost> AdicionaUsuario(UsuarioPost usuarioPost);
        Task<UsuarioPut> AtualizaUsuario(UsuarioPut usuarioPut);
        Task<bool> ExisteUsuario();
        Task<UsuarioPut> DeletaUsuarioPorId(int id);
    }
}
